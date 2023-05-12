using System.Runtime;

namespace SkillFactory_Module_8._6_part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("\\\\Mac\\Home\\Desktop\\Test");
            try
            {

                if (dir.Exists)
                {

                    DirectoryInfo[] diArr = dir.GetDirectories(); 
                    FileInfo[] fiArr = dir.GetFiles();
                    FilesDelete(fiArr);
                    DirectoryDelete(diArr); 
                    

                }


            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
            }
            catch(UnauthorizedAccessException ex) {

                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
                
        }


        static void DirectoryDelete(DirectoryInfo[] vs) 
        {
            double duration;

            for (int i = 0; i < vs.Length; i++) 
            {
                duration = (DateTime.Now - vs[i].LastAccessTime).TotalMinutes; 
                if (duration > 30)                                             
                {
                    //Console.WriteLine($"{vs[i].Name} Directory deleting");
                    vs[i].Delete(true);
                }
            }
        }
        static void FilesDelete(FileInfo[] fl)  
        {
            double duration;
            for (int i = 0; i < fl.Length; i++)  
            {
                duration = (DateTime.Now - fl[i].LastAccessTime).TotalMinutes; 
                if (duration > 30)                                             
                {
                    //Console.WriteLine($"{fl[i].Name} File deleting");
                    fl[i].Delete();
                }
            }
        }
    }
}