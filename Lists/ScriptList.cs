
namespace GenieClient.Genie
{
    public class ScriptList : Collections.CollectionList
    {
        public GenieClient.Script this[int Index]
        {
            get
            {
                return (GenieClient.Script)List[Index];
            }

            set
            {
                List[Index] = value;
            }
        }

        public int Add(GenieClient.Script Item)
        {
            return List.Add(Item);
        }

        public void Remove(GenieClient.Script Item)
        {
            List.Remove(Item);
        }
    }
}