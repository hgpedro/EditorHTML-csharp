using System;
using System.Text;
using System.IO;

namespace EditorHtml
{   
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-----------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            Console.WriteLine("-----------");
            Viewer.Show(file.ToString());
            Save(file);
        }  

        static void Save(StringBuilder file)
        {
            Console.WriteLine(">Deseja salvar o arquivo?(S/N)");

            var option = Console.ReadLine().ToLower();
            
            switch(option){
                case "s": SaveLocal(file); break;
                case "n": Menu.Show(); break;
                default: Save(file); break;
            }
        }

        static void SaveLocal(StringBuilder file)
        {
            Console.Clear();
            Console.WriteLine("- Qual caminho para salvar o arquivo?");
            
            var path = Console.ReadLine();

            using(var fileSave = new StreamWriter(path)) 
            {
                fileSave.Write(file);
            }
            Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
            Console.WriteLine("Aperte ENTER para voltar ao Menu...");
            Console.ReadLine();
            Menu.Show();


        }
    }
}    