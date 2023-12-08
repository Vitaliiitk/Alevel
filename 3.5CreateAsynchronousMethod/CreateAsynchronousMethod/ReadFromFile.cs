using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAsynchronousMethod
{
    public sealed class ReadFromFile
    {
        public async Task<string> ReadFromTxt(string txtName) 
        {
            var lines = await File.ReadAllLinesAsync(txtName);



            return lines[0];
        }

        public async Task<string> ConcatetionOfText()
        {
            string lines = await ReadFromTxt("HelloFile.txt") + await ReadFromTxt("WorldFile.txt");

            return lines;
        }
    }
}
