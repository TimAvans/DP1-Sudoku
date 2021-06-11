using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Factory.Parser
{
    class JigsawParser : IParser
    {
        public const string TYPE = "jigsaw";

        public IParser Clone()
        {
            return (JigsawParser)MemberwiseClone();
        }

        public List<Dictionary<string, int>> Parse(List<string> file)
        {
            List<Dictionary<string, int>> cell_data = new List<Dictionary<string, int>>();

            foreach (string line in file)
            {
                string[] data = line.Split('=');

                int x = 0;
                int y = 0;
                int width = (int)Math.Sqrt(data.Length - 1);
                for(int i = 1; i < data.Length; i++)
                {
                    cell_data.Add(new Dictionary<string, int>() {
                        { "value",  (int)Char.GetNumericValue(data[i].Split('J')[0][0]) },
                        { "region", (int)Char.GetNumericValue(data[i].Split('J')[1][0]) },
                        { "superregion", 0 },
                        { "x", x},
                        { "y", y }
                    });
                    
                    if(x + 1 == width)
                    {
                        x = 0;
                        y++;
                    } else
                    {
                        x++;
                    }
                }
            }
            return cell_data;
        }

        public string Type()
        {
            return TYPE;
        }
    }
}
