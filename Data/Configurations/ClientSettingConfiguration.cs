using GenieClient.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Data.Configurations
{
    public class ClientSettingConfiguration : IEntityTypeConfiguration<ClientSetting>
    {
        public void Configure(EntityTypeBuilder<ClientSetting> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.Property(p => p.Id)
            //    .IsRequired()
            //    .ValueGeneratedOnAdd();

            builder.HasData(
                new ClientSetting
                {
                    BufferLineSize = 5,
                    Editor = "notepad.exe",
                    IgnoreCloseAlert = false,
                    MaxArguments = 15,
                    Prompt  = "> ",
                    Command = '#',
                    Separator = ';',
                    Script = '.',
                    Send = '-',
                    Parse = '/',
                    MaxGoSubDepth = 50,
                    Timeout = 5000,
                    IgnoreWarnings = false,
                    AbortDuplicates = true
                });
        }
}
}
