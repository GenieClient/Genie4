using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public class Crypto
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum KeySize : int
        {
            RC2 = 64,
            DES = 64,
            TripleDES = 192,
            AES = 128,
            RSA = 2048
        }

        public enum Algorithm : int
        {
            SHA1 = 0,
            SHA256 = 1,
            SHA384 = 2,
            Rijndael = 3,
            TripleDES = 4,
            RSA = 5,
            RC2 = 6,
            DES = 7,
            // DSA = 8
            MD5 = 9,
            RNG = 10,
            // Base64 = 11
            SHA512 = 12
        }

        public enum EncodingType : int
        {
            HEX = 0,
            BASE_64 = 1
        }

        // Initialization Vectors that we will use for symmetric encryption/decryption. These
        // byte arrays are completely arbitrary, and you can change them to whatever you like.
        private static byte[] IV_8 = new byte[] { 2, 63, 9, 36, 235, 174, 78, 12 };
        private static byte[] IV_16 = new byte[] { 15, 199, 56, 77, 244, 126, 107, 239, 9, 10, 88, 72, 24, 202, 31, 108 };
        private static byte[] IV_24 = new byte[] { 37, 28, 19, 44, 25, 170, 122, 25, 25, 57, 127, 5, 22, 1, 66, 65, 14, 155, 224, 64, 9, 77, 18, 251 };

        private static byte[] IV_32 = new byte[] { 133, 206, 56, 64, 110, 158, 132, 22, 99, 190, 35, 129, 101, 49, 204, 248, 251, 243, 13, 194, 160, 195, 89, 152, 149, 227, 245, 5, 218, 86, 161, 124 };



        // Salt value used to encrypt a plain text key. Again, this can be whatever you like
        private static byte[] SALT_BYTES = new byte[] { 162, 27, 98, 1, 28, 239, 64, 30, 156, 102, 223 };

        // File names to be used for public and private keys
        private const string KEY_PUBLIC = "public.key";
        private const string KEY_PRIVATE = "private.key";

        // Values used for RSA-based asymmetric encryption
        private const int RSA_BLOCKSIZE = 58;
        private const int RSA_DECRYPTBLOCKSIZE = 128;

        // Error messages
        private const string ERR_NO_KEY = "No encryption key was provided";
        private const string ERR_NO_ALGORITHM = "No algorithm was specified";
        private const string ERR_NO_CONTENT = "No content was provided";
        private const string ERR_INVALID_PROVIDER = "An invalid cryptographic provider was specified for this method";
        private const string ERR_NO_FILE = "The specified file does not exist";
        private const string ERR_INVALID_FILENAME = "The specified filename is invalid";
        private const string ERR_FILE_WRITE = "Could not create file";
        private const string ERR_FILE_READ = "Could not read file";

        // Initialization variables
        private static string _key;
        private static Algorithm _algorithm = (Algorithm)(-1);
        private static string _content;
        private static CryptographicException _exception;
        private static EncodingType _encodingType = EncodingType.HEX;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [Description("The key that is used to encrypt and decrypt data")]
        public static string Key
        {
            get
            {
                return _key;
            }

            set
            {
                _key = value;
            }
        }

        [Description("The algorithm that will be used for encryption and decryption")]
        public static Algorithm EncryptionAlgorithm
        {
            get
            {
                return _algorithm;
            }

            set
            {
                _algorithm = value;
            }
        }

        [Description("The format in which content is returned after encryption, or provided for decryption")]
        public static EncodingType Encoding
        {
            get
            {
                return _encodingType;
            }

            set
            {
                _encodingType = value;
            }
        }

        [Description("Encrypted content to be retrieved after an encryption call, or provided for a decryption call")]
        public static string Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }

        [Description("If an encryption or decryption call returns false, then this will contain the exception")]
        public static CryptographicException CryptoException
        {
            get
            {
                return _exception;
            }
        }

        [Description("Determines whether the currently specified algorithm is a hash")]
        public static bool IsHashAlgorithm
        {
            get
            {
                var switchExpr = _algorithm;
                switch (switchExpr)
                {
                    case Algorithm.MD5:
                    case Algorithm.SHA1:
                    case Algorithm.SHA256:
                    case Algorithm.SHA384:
                    case Algorithm.SHA512:
                        {
                            return true;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }
        }

        [Description("Encryption of a string using the 'Key' and 'EncryptionAlgorithm' properties")]
        public static bool EncryptString(string Content)
        {
            byte[] cipherBytes;
            try
            {
                cipherBytes = _Encrypt(Content);
            }
            catch (CryptographicException ex)
            {
                _exception = new CryptographicException(ex.Message, ex.InnerException);
                return false;
            }

            if (_encodingType == EncodingType.HEX)
            {
                _content = BytesToHex(cipherBytes);
            }
            else
            {
                _content = Convert.ToBase64String(cipherBytes);
            }

            return true;
        }

        public static bool DecryptString()
        {
            // byte[] encText = null;
            byte[] clearText = null;
            try
            {
                clearText = _Decrypt(_content);
            }
            catch (Exception ex)
            {
                _exception = new CryptographicException(ex.Message, ex.InnerException);
                return false;
            }

            _content = System.Text.Encoding.UTF8.GetString(clearText);
            return true;
        }

        public static bool EncryptFile(string Filename, string Target)
        {
            if (!File.Exists(Filename))
            {
                _exception = new CryptographicException(ERR_NO_FILE);
                return false;
            }

            // Make sure the target file can be written
            try
            {
                var fs = File.Create(Target);
                fs.Close();
                fs.Dispose();
                File.Delete(Target);
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                _exception = new CryptographicException(ERR_FILE_WRITE);
                return false;
            }

            byte[] inStream;
            byte[] cipherBytes;
            try
            {
                inStream = File.ReadAllBytes(Filename);
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                _exception = new CryptographicException(ERR_FILE_READ);
                return false;
            }

            try
            {
                cipherBytes = _Encrypt(inStream);
            }
            catch (CryptographicException ex)
            {
                _exception = ex;
                return false;
            }

            string encodedString = string.Empty;
            if (_encodingType == EncodingType.BASE_64)
            {
                encodedString = Convert.ToBase64String(cipherBytes);
            }
            else
            {
                encodedString = BytesToHex(cipherBytes);
            }

            var encodedBytes = System.Text.Encoding.UTF8.GetBytes(encodedString);

            // Create the encrypted file
            var outStream = File.Create(Target);
            outStream.Write(encodedBytes, 0, encodedBytes.Length);
            outStream.Close();
            outStream.Dispose();
            return true;
        }

        public static bool DecryptFile(string Filename, string Target)
        {
            if (!File.Exists(Filename))
            {
                _exception = new CryptographicException(ERR_NO_FILE);
                return false;
            }

            // Make sure the target file can be written
            try
            {
                var fs = File.Create(Target);
                fs.Close();
                fs.Dispose();
                File.Delete(Target);
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                _exception = new CryptographicException(ERR_FILE_WRITE);
                return false;
            }

            byte[] inStream;
            byte[] clearBytes;
            try
            {
                inStream = File.ReadAllBytes(Filename);
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                _exception = new CryptographicException(ERR_FILE_READ);
                return false;
            }

            try
            {
                clearBytes = _Decrypt(inStream);
            }
            catch (Exception ex)
            {
                _exception = new CryptographicException(ex.Message, ex.InnerException);
                return false;
            }

            // Create the decrypted file
            var outStream = File.Create(Target);
            outStream.Write(clearBytes, 0, clearBytes.Length);
            outStream.Close();
            outStream.Dispose();
            return true;
        }

        public static bool GenerateHash(string Content)
        {
            if (Content is null || Content.Equals(string.Empty))
            {
                _exception = new CryptographicException(ERR_NO_CONTENT);
                return false;
            }

            if (_algorithm.Equals(-1))
            {
                _exception = new CryptographicException(ERR_NO_ALGORITHM);
                return false;
            }

            HashAlgorithm hashAlgorithm = null;
            var switchExpr = _algorithm;
            switch (switchExpr)
            {
                case Algorithm.SHA1:
                    {
                        hashAlgorithm = new SHA1CryptoServiceProvider();
                        break;
                    }

                case Algorithm.SHA256:
                    {
                        hashAlgorithm = new SHA256Managed();
                        break;
                    }

                case Algorithm.SHA384:
                    {
                        hashAlgorithm = new SHA384Managed();
                        break;
                    }

                case Algorithm.SHA512:
                    {
                        hashAlgorithm = new SHA512Managed();
                        break;
                    }

                case Algorithm.MD5:
                    {
                        hashAlgorithm = new MD5CryptoServiceProvider();
                        break;
                    }

                default:
                    {
                        _exception = new CryptographicException(ERR_INVALID_PROVIDER);
                        break;
                    }
            }

            try
            {
                var hash = ComputeHash(hashAlgorithm, Content);
                if (_encodingType == EncodingType.HEX)
                {
                    _content = BytesToHex(hash);
                }
                else
                {
                    _content = Convert.ToBase64String(hash);
                }

                hashAlgorithm.Clear();
                return true;
            }
            catch (CryptographicException ex)
            {
                _exception = ex;
                return false;
            }
            finally
            {
                hashAlgorithm.Clear();
            }
        }

        public static void Clear()
        {
            _algorithm = (Algorithm)(-1);
            _content = string.Empty;
            _key = string.Empty;
            _encodingType = EncodingType.HEX;
            _exception = null;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private static byte[] _Encrypt(byte[] Content)
        {
            if (!IsHashAlgorithm && _key is null)
            {
                throw new CryptographicException(ERR_NO_KEY);
            }

            if (_algorithm.Equals(-1))
            {
                throw new CryptographicException(ERR_NO_ALGORITHM);
            }

            if (Content is null || Content.Equals(string.Empty))
            {
                throw new CryptographicException(ERR_NO_CONTENT);
            }

            byte[] cipherBytes = null;
            int NumBytes = 0;
            if (_algorithm == Algorithm.RSA)
            {
                // This is an asymmetric call, which has to be treated differently
                try
                {
                    cipherBytes = RSAEncrypt(Content);
                }
                catch (CryptographicException ex)
                {
                    throw ex;
                }
            }
            else
            {
                SymmetricAlgorithm provider;
                var switchExpr = _algorithm;
                switch (switchExpr)
                {
                    case Algorithm.DES:
                        {
                            provider = new DESCryptoServiceProvider();
                            NumBytes = (int)KeySize.DES;
                            break;
                        }

                    case Algorithm.TripleDES:
                        {
                            provider = new TripleDESCryptoServiceProvider();
                            NumBytes = (int)KeySize.TripleDES;
                            break;
                        }

                    case Algorithm.Rijndael:
                        {
                            provider = new RijndaelManaged();
                            NumBytes = (int)KeySize.AES;
                            break;
                        }

                    case Algorithm.RC2:
                        {
                            provider = new RC2CryptoServiceProvider();
                            NumBytes = (int)KeySize.RC2;
                            break;
                        }

                    default:
                        {
                            throw new CryptographicException(ERR_INVALID_PROVIDER);
                        }
                }

                try
                {
                    // Encrypt the string
                    cipherBytes = SymmetricEncrypt(provider, Content, _key, NumBytes);
                }
                catch (CryptographicException ex)
                {
                    throw new CryptographicException(ex.Message, ex.InnerException);
                }
                finally
                {
                    // Free any resources held by the SymmetricAlgorithm provider
                    provider.Clear();
                }
            }

            return cipherBytes;
        }

        private static byte[] _Encrypt(string Content)
        {
            return _Encrypt(System.Text.Encoding.UTF8.GetBytes(Content));
        }

        private static byte[] _Decrypt(byte[] Content)
        {
            if (!IsHashAlgorithm && _key is null)
            {
                throw new CryptographicException(ERR_NO_KEY);
            }

            if (_algorithm.Equals(-1))
            {
                throw new CryptographicException(ERR_NO_ALGORITHM);
            }

            if (Content is null || Content.Length.Equals(0))
            {
                throw new CryptographicException(ERR_NO_CONTENT);
            }

            string encText = System.Text.Encoding.UTF8.GetString(Content);
            if (_encodingType == EncodingType.BASE_64)
            {
                // We need to convert the content to Hex before decryption
                encText = BytesToHex(Convert.FromBase64String(encText));
            }

            byte[] clearBytes = null;
            int NumBytes = 0;
            if (_algorithm == Algorithm.RSA)
            {
                try
                {
                    clearBytes = RSADecrypt(encText);
                }
                catch (CryptographicException ex)
                {
                    throw ex;
                }
            }
            else
            {
                SymmetricAlgorithm provider;
                var switchExpr = _algorithm;
                switch (switchExpr)
                {
                    case Algorithm.DES:
                        {
                            provider = new DESCryptoServiceProvider();
                            NumBytes = (int)KeySize.DES;
                            break;
                        }

                    case Algorithm.TripleDES:
                        {
                            provider = new TripleDESCryptoServiceProvider();
                            NumBytes = (int)KeySize.TripleDES;
                            break;
                        }

                    case Algorithm.Rijndael:
                        {
                            provider = new RijndaelManaged();
                            NumBytes = (int)KeySize.AES;
                            break;
                        }

                    case Algorithm.RC2:
                        {
                            provider = new RC2CryptoServiceProvider();
                            NumBytes = (int)KeySize.RC2;
                            break;
                        }

                    default:
                        {
                            throw new CryptographicException(ERR_INVALID_PROVIDER);
                        }
                }

                try
                {
                    clearBytes = SymmetricDecrypt(provider, encText, _key, NumBytes);
                }
                catch (CryptographicException ex)
                {
                    throw ex;
                }
                finally
                {
                    // Free any resources held by the SymmetricAlgorithm provider
                    provider.Clear();
                }
            }

            // Now return the plain text content
            return clearBytes;
        }

        private static byte[] _Decrypt(string Content)
        {
            return _Decrypt(System.Text.Encoding.UTF8.GetBytes(Content));
        }

        private static byte[] ComputeHash(HashAlgorithm Provider, string plainText)
        {
            // All hashing mechanisms inherit from the HashAlgorithm base class so we can use that to cast the crypto service provider
            var hash = Provider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainText));
            Provider.Clear();
            return hash;
        }

        private static byte[] SymmetricEncrypt(SymmetricAlgorithm Provider, byte[] plainText, string key, int keySize)
        {
            // All symmetric algorithms inherit from the SymmetricAlgorithm base class, to which we can cast from the original crypto service provider
            byte[] ivBytes = null;
            var switchExpr = keySize / (double)8; // Determine which initialization vector to use
            switch (switchExpr)
            {
                case 8:
                    {
                        ivBytes = IV_8;
                        break;
                    }

                case 16:
                    {
                        ivBytes = IV_16;
                        break;
                    }

                case 24:
                    {
                        ivBytes = IV_24;
                        break;
                    }

                case 32:
                    {
                        ivBytes = IV_32;
                        break;
                    }

                default:
                    {
                        break;
                    }
                    // TODO: Throw an error because an invalid key length has been passed
            }

            Provider.KeySize = keySize;

            // Generate a secure key based on the original password by using SALT
            var keyStream = DerivePassword(key, (int)(keySize / (double)8));

            // Initialize our encryptor object
            var trans = Provider.CreateEncryptor(keyStream, ivBytes);

            // Perform the encryption on the textStream byte array
            var result = trans.TransformFinalBlock(plainText, 0, plainText.GetLength(0));

            // Release cryptographic resources
            Provider.Clear();
            trans.Dispose();
            return result;
        }

        private static byte[] SymmetricDecrypt(SymmetricAlgorithm Provider, string encText, string key, int keySize)
        {
            // All symmetric algorithms inherit from the SymmetricAlgorithm base class, to which we can cast from the original crypto service provider
            byte[] ivBytes = null;
            var switchExpr = keySize / (double)8; // Determine which initialization vector to use
            switch (switchExpr)
            {
                case 8:
                    {
                        ivBytes = IV_8;
                        break;
                    }

                case 16:
                    {
                        ivBytes = IV_16;
                        break;
                    }

                case 24:
                    {
                        ivBytes = IV_24;
                        break;
                    }

                case 32:
                    {
                        ivBytes = IV_32;
                        break;
                    }

                default:
                    {
                        break;
                    }
                    // TODO: Throw an error because an invalid key length has been passed
            }

            // Generate a secure key based on the original password by using SALT
            var keyStream = DerivePassword(key, (int)(keySize / (double)8));

            // Convert our hex-encoded cipher text to a byte array
            var textStream = HexToBytes(encText);
            Provider.KeySize = keySize;

            // Initialize our decryptor object
            var trans = Provider.CreateDecryptor(keyStream, ivBytes);

            // Initialize the result stream
            byte[] result = null;
            try
            {
                // Perform the decryption on the textStream byte array
                result = trans.TransformFinalBlock(textStream, 0, textStream.GetLength(0));
            }
            catch (Exception ex)
            {
                throw new CryptographicException("The following exception occurred during decryption: " + ex.Message);
            }
            finally
            {
                // Release cryptographic resources
                Provider.Clear();
                trans.Dispose();
            }

            return result;
        }

        private static byte[] RSAEncrypt(byte[] plainText)
        {
            // Make sure that the public and private key exists
            ValidateRSAKeys();
            string publicKey = GetTextFromFile(KEY_PUBLIC);
            string privateKey = GetTextFromFile(KEY_PRIVATE);

            // The RSA algorithm works on individual blocks of unencoded bytes. In this case, the
            // maximum is 58 bytes. Therefore, we are required to break up the text into blocks and
            // encrypt each one individually. Each encrypted block will give us an output of 128 bytes.
            // If we do not break up the blocks in this manner, we will throw a "key not valid for use
            // in specified state" exception

            // Get the size of the final block
            int lastBlockLength = plainText.Length % RSA_BLOCKSIZE;
            int blockCount = Conversions.ToInteger(Math.Floor(plainText.Length / (double)RSA_BLOCKSIZE));
            bool hasLastBlock = false;
            if (!lastBlockLength.Equals(0))
            {
                // We need to create a final block for the remaining characters
                blockCount += 1;
                hasLastBlock = true;
            }

            // Initialize the result buffer
            var result = new byte[] { };

            // Initialize the RSA Service Provider with the public key
            var Provider = new RSACryptoServiceProvider((int)KeySize.RSA);
            Provider.FromXmlString(publicKey);

            // Break the text into blocks and work on each block individually
            for (int blockIndex = 0, loopTo = blockCount - 1; blockIndex <= loopTo; blockIndex++)
            {
                int thisBlockLength;

                // If this is the last block and we have a remainder, then set the length accordingly
                if (blockCount.Equals(blockIndex + 1) && hasLastBlock)
                {
                    thisBlockLength = lastBlockLength;
                }
                else
                {
                    thisBlockLength = RSA_BLOCKSIZE;
                }

                int startChar = blockIndex * RSA_BLOCKSIZE;

                // Define the block that we will be working on
                var currentBlock = new byte[thisBlockLength];
                Array.Copy(plainText, startChar, currentBlock, 0, thisBlockLength);

                // Encrypt the current block and append it to the result stream
                var encryptedBlock = Provider.Encrypt(currentBlock, false);
                int originalResultLength = result.Length;
                Array.Resize(ref result, originalResultLength + encryptedBlock.Length);
                encryptedBlock.CopyTo(result, originalResultLength);
            }

            // Release any resources held by the RSA Service Provider
            Provider.Clear();
            return result;
        }

        private static byte[] RSADecrypt(string encText)
        {
            // Make sure that the public and private key exists
            ValidateRSAKeys();
            string publicKey = GetTextFromFile(KEY_PUBLIC);
            string privateKey = GetTextFromFile(KEY_PRIVATE);

            // When we encrypt a string using RSA, it works on individual blocks of up to
            // 58 bytes. Each block generates an output of 128 encrypted bytes. Therefore, to
            // decrypt the message, we need to break the encrypted stream into individual
            // chunks of 128 bytes and decrypt them individually

            // Determine how many bytes are in the encrypted stream. The input is in hex format,
            // so we have to divide it by 2
            int maxBytes = (int)(encText.Length / (double)2);

            // Ensure that the length of the encrypted stream is divisible by 128
            if (!(maxBytes % RSA_DECRYPTBLOCKSIZE).Equals(0))
            {
                throw new CryptographicException("Encrypted text is an invalid length");
            }

            // Calculate the number of blocks we will have to work on
            int blockCount = (int)(maxBytes / (double)RSA_DECRYPTBLOCKSIZE);

            // Initialize the result buffer
            var result = new byte[] { };

            // Initialize the RSA Service Provider
            var Provider = new RSACryptoServiceProvider((int)KeySize.RSA);
            Provider.FromXmlString(privateKey);

            // Iterate through each block and decrypt it
            for (int blockIndex = 0, loopTo = blockCount - 1; blockIndex <= loopTo; blockIndex++)
            {
                // Get the current block to work on
                object currentBlockHex = encText.Substring(blockIndex * RSA_DECRYPTBLOCKSIZE * 2, RSA_DECRYPTBLOCKSIZE * 2);
                var currentBlockBytes = HexToBytes(Conversions.ToString(currentBlockHex));

                // Decrypt the current block and append it to the result stream
                var currentBlockDecrypted = Provider.Decrypt(currentBlockBytes, false);
                int originalResultLength = result.Length;
                Array.Resize(ref result, originalResultLength + currentBlockDecrypted.Length);
                currentBlockDecrypted.CopyTo(result, originalResultLength);
            }

            // Release all resources held by the RSA service provider
            Provider.Clear();
            return result;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */    // ********************************************************
                                                           // * BytesToHex: Converts a byte array to a hex-encoded
                                                           // *             string
                                                           // ********************************************************
        private static string BytesToHex(byte[] bytes)
        {
            var hex = new StringBuilder();
            for (int n = 0, loopTo = bytes.Length - 1; n <= loopTo; n++)
                hex.AppendFormat("{0:X2}", bytes[n]);
            return hex.ToString();
        }

        // ********************************************************
        // * HexToBytes: Converts a hex-encoded string to a
        // *             byte array
        // ********************************************************
        private static byte[] HexToBytes(string Hex)
        {
            int numBytes = (int)(Hex.Length / (double)2);
            var bytes = new byte[numBytes];
            for (int n = 0, loopTo = numBytes - 1; n <= loopTo; n++)
            {
                string hexByte = Hex.Substring(n * 2, 2);
                bytes[n] = Conversions.ToByte(int.Parse(hexByte, System.Globalization.NumberStyles.HexNumber));
            }

            return bytes;
        }

        // ********************************************************
        // * ClearBuffer: Clears a byte array to ensure
        // *              that it cannot be read from memory
        // ********************************************************
        private static void ClearBuffer(byte[] bytes)
        {
            if (bytes is null)
                return;
            for (int n = 0, loopTo = bytes.Length - 1; n <= loopTo; n++)
                bytes[n] = 0;
        }

        // ********************************************************
        // * GenerateSalt: No, this is not a culinary routine. This
        // *               generates a random salt value for
        // *               password generation
        // ********************************************************
        private static byte[] GenerateSalt(int saltLength)
        {
            byte[] salt;
            if (saltLength > 0)
            {
                salt = new byte[saltLength + 1];
            }
            else
            {
                salt = new byte[1];
            }

            var seed = new RNGCryptoServiceProvider();
            seed.GetBytes(salt);
            return salt;
        }

        // ********************************************************
        // * DerivePassword: This takes the original plain text key
        // *                 and creates a secure key using SALT
        // ********************************************************
        private static byte[] DerivePassword(string originalPassword, int passwordLength)
        {
            var derivedBytes = new Rfc2898DeriveBytes(originalPassword, SALT_BYTES, 5);
            return derivedBytes.GetBytes(passwordLength);
        }

        // ********************************************************
        // * ValidateRSAKeys: Checks for the existence of a public
        // *                  and private key file and creates them
        // *                  if they do not exist
        // ********************************************************
        private static void ValidateRSAKeys()
        {
            if (!File.Exists(KEY_PRIVATE) || !File.Exists(KEY_PUBLIC))
            {
                // Dim rsa As New RSACryptoServiceProvider
                var key = RSA.Create();
                key.KeySize = (int)KeySize.RSA;
                string privateKey = key.ToXmlString(true);
                string publicKey = key.ToXmlString(false);
                var privateFile = File.CreateText(KEY_PRIVATE);
                privateFile.Write(privateKey);
                privateFile.Close();
                privateFile.Dispose();
                var publicFile = File.CreateText(KEY_PUBLIC);
                publicFile.Write(publicKey);
                publicFile.Close();
                publicFile.Dispose();
            }
        }

        // ********************************************************
        // * GetTextFromFile: Reads the text from a file
        // ********************************************************
        private static string GetTextFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                var textFile = File.OpenText(fileName);
                string result = textFile.ReadToEnd();
                textFile.Close();
                textFile.Dispose();
                return result;
            }
            else
            {
                throw new IOException("Specified file does not exist");
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}