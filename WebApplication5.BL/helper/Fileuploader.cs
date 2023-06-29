


namespace WebApplication5.BL.helper;

    public static class Fileuploader
    {//this class help to uplad images and cv of each employee
        public static string uploader(string foldername, IFormFile myfile)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "/wwwroot/files/" + foldername;
                string filename = Guid.NewGuid() + Path.GetFileName(myfile.FileName);
                string finalpath = Path.Combine(path, filename);
                using (var stream = new FileStream(finalpath, FileMode.Create))
                {
                    myfile.CopyTo(stream);
                }

                return filename;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        public  static void delete(string foldername, string filename)
        {
            try
            {
                var path = Directory.GetCurrentDirectory() + "/wwwroot/files/" + foldername + filename;
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
               
            }catch(Exception e)
            {

            }
        }
    }

