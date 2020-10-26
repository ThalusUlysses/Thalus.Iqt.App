using Newtonsoft.Json;
using System.IO;
using Thalus.Contracts;
using Thalus.Iqt.Core;

namespace Thalus.Iqt.App
{
    class IqtOutFileAccess
    {
        public IResult Write(IqtIdentitySetDTO set, string fileName, bool overwrite = false)
        {
            var obj = JsonConvert.SerializeObject(set);

            FileInfo fi = new FileInfo(fileName);

            if (fi.Exists && overwrite)
            {
                File.Delete(fileName);
            }

            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }

            File.WriteAllText(fileName, obj);

            return Result.Ok();
        }

        public IResult Write(IqtIdentityResultSetDTO set, string fileName, bool overwrite = false)
        {
            var obj = JsonConvert.SerializeObject(set);

            FileInfo fi = new FileInfo(fileName);

            if (fi.Exists && overwrite)
            {
                File.Delete(fileName);
            }

            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }

            File.WriteAllText(fileName, obj);

            return Result.Ok();
        }

        public IResult Read(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return Result.Fail(404, $"File or path {fileName} does not exist");
            }

            var txt = File.ReadAllText(fileName);

            var obj = JsonConvert.DeserializeObject<IqtIdentitySetDTO>(txt);

            return Result.Ok(data: obj);
        }
    }
}
