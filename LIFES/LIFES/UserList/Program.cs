using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
//using "User.cs";

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            User test = new User("Jordan", "Beck", true);
            User test2 = new User("Josh", "Ford", false);
            User test3 = new User("Jeff", "NiggaUGay", false);
            */
            UserList oneList = new UserList();

            oneList.AddUser("Ricky", "Bobby", false);
            oneList.AddUser("Ricky", "Bobby", false);
            oneList.AddUser("Ricky", "Bobby", false);
            oneList.AddUser("Ricky", "Bobby", false);
            oneList.AddUser("Jordan","Beck",true);
            oneList.AddUser("Josh","Ford",false);
            oneList.AddUser("Red","ROVER!", true);
            //oneList.DelUser("Jordan");
            oneList.AddUser("Jordan", "pav", true);

            oneList.changePassword("Jordan", "Red");
            oneList.testPassword("Jordan", "Red2");
            oneList.testPassword("Jordan", "Red");
            oneList.testPassword("Jordan", "Red2");
            oneList.testPassword("Jordan", "Red2");
            oneList.testPassword("Jordan", "Red2");
            oneList.testPassword("Jordan", "Red2");
            oneList.testPassword("Jordan", "Red");


            if (oneList.isAdmin("Josh"))
            {
                Console.Out.WriteLine("Correct");
            }

            if (oneList.IsUser("Jordan"))//,"Beck"))
            {
                Console.Out.WriteLine("Jordan");
                Console.Out.WriteLine("Is User");
            }
            else
            {
                Console.Out.WriteLine("Jordan");
                Console.Out.WriteLine("Is not User");
            }

            //oneList.DelUser("Josh");

            if (oneList.IsUser("Josh"))//,"Ford"))
            {
                Console.Out.WriteLine("Josh");
                Console.Out.WriteLine("Is User");
            }
            else
            {
                Console.Out.WriteLine("Josh");
                Console.Out.WriteLine("Is not User");
            }
            
            
            if (oneList.IsUser("Jeff"))//,"test"))
            {
                Console.Out.WriteLine("Jeff");
                Console.Out.WriteLine("Is User");
            }
            else
            {
                Console.Out.WriteLine("Jeff");
                Console.Out.WriteLine("Is not User");
            }
            Console.ReadLine();
        }
    }
}


public class UserList
{
    string ioFile = "C:/Users/Public/TestFolder/Username2.txt";

    public UserList()
    {
        //Opens or creates file
        FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        file.Close();
    }

    public void AddUser(string userName, string password, bool admin)
    {
        // Block compares username to check if taken.
        /*
        using (StreamReader reader = new StreamReader
        (@ioFile))
        {
            string file = "";
            string test = userName;
            test = test + " ";

            //Checks to see if Username is taken
            while ((file = reader.ReadLine()) != null)
            {
                int i = 0;
                if (!String.IsNullOrEmpty(file))
                {

                    while (file[i] == test[i])
                    {
                        if ((file[i] == ' ') && (test[i] == ' '))
                        {
                            //UserName is Taken
                            return;
                        }
                        i++;
                    }
                }
            }
            reader.Close();

        }
        //*/
        if (IsUser(userName))
        {
            return;
        }
        //This block creates the line to input into the file.
        string line = "";
        line = userName;
        line = line + " ";
        line = line + password;
        line = line + " ";
        if (admin)
        {
            line = line + "1";
        }
        else
        {
            line = line + "0";
        }

        //Adds the field for number of attempts
        line = line + " 0";

        //Input to User to Doc
        using (StreamWriter writeFile = File.AppendText(@ioFile))
        {
            writeFile.WriteLine(line);
            writeFile.Close();
        }
    }

    public bool IsUser(string userName)// , string password)
    {
        string testName = "";
        //string testPass = "";

        using (StreamReader reader = new StreamReader(@ioFile))
        {
            string line;

            // Block compares username and passwords.
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;
                testName = "";
               // testPass = "";
                if (!String.IsNullOrEmpty(line))
                {
                    //Gets Name
                    while (!((line[i] == ' ') || (line[i] == '\n')))
                    {
                        testName = testName + line[i];
                        i++;
                    }
                    //i++;

                    //Gets Password
                    /*
                    while (!(line[i] == ' '))
                    {
                        testPass = testPass + line[i];
                        i++;
                    }
                    */
                    //Test to see if the same
                    if (testName == userName)//&& testPass == password)
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            reader.Close();
        }
        return false;
    }

    public void changePassword(string inputName, string inputPassword)
    {
        string actualName = inputName;
        inputName = inputName + " ";
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            string line = "";
            int i = 0;
            int row = 0;
            while ((line = reader.ReadLine()) != null)
            {
                row++;
                //if(line[i])
                while (line[i] == inputName[i])
                {
                    if (line[i] == ' ')
                    {
                        reader.Close();
                        ChangeFilePassword(actualName, inputPassword);
                        return;
                    }
                    i++;
                }
            }
        }
    }

    public bool testPassword(string inputName, string inputPassword)
    {
        char attemptsAllowed = '4';
        bool isCorrect = false;
        string input = inputName + " " + inputPassword + " ";
        int row = 0;
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;
                row++;
                if (line[i] == input[i])
                {
                    do
                    {
                        i++;
                        if ((line[i] == input[i]) && (line[i] == ' '))
                        {
                            do
                            {
                                i++;
                                if ((line[i] == input[i]) && (line[i] == ' '))
                                {
                                    //Doesn't Allow for over 4 attempts
                                    if (line[i + 3] == attemptsAllowed)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        reader.Close();
                                        ResetAttemptTry(row, i + 3);
                                    }

                                    isCorrect = true;
                                    return isCorrect;
                                }
                                if (line[i] != input[i])
                                {
                                    while (line[i] != ' ')
                                    {
                                        i++;
                                    }
                                    reader.Close();
                                    IncreaseAttemptTry(row, i + 3);
                                    return isCorrect;
                                }
                            } while (line[i] == input[i]);

                        }
                    } while (line[i] == input[i]);
                }
            }
            reader.Close();
        }
        return isCorrect;
    }

    public void DelUser(string inputName)
    {
        inputName = inputName + " ";
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            string line = "";
            int row = 0;
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;
                row++;
                if (!String.IsNullOrEmpty(line))
                {
                    if (line[i] == inputName[i])
                    {
                        do
                        {
                            i++;
                            if (line[i] == ' ')
                            {
                                //removes line by rewriting the Username file
                                reader.Close();
                                ReWriteFile(row);
                                return;
                            }
                        } while ((line[i] == inputName[i]) && (line[i] != ' '));
                    }
                }
            }
            reader.Close();
        }
    }

    public bool isAdmin(string inputName)
    {
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;

                if ((!String.IsNullOrEmpty(line)) && (line[i] == inputName[i]))
                {
                    do
                    {
                        i++;
                        if (line[i] == ' ')
                        {
                            do
                            {
                                i++;
                            } while (!(line[i] == ' '));
                            //
                            if (line[i + 1] == '0')
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    } while (line[i] == inputName[i]);
                }
            }
            reader.Close();
        }
        return false;
    }

    private void ReWriteFile(int rowRemove)
    {
        string fileToWrite = "";
        //Reads through the file and creates a new file
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            string line = "";
            int row = 0;
            while ((line = reader.ReadLine()) != null)
            {
                row++;
                if (row != rowRemove)
                {
                    fileToWrite = fileToWrite + line;
                    fileToWrite = fileToWrite + '\n';
                }
            }
            reader.Close();
        }
        //Del file
        File.Delete(@ioFile);
        //recreate file
        FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        file.Close();
        //writes fileToWrite to file
        using (StreamWriter writeFile = File.AppendText(@ioFile))
        {
            writeFile.Write(fileToWrite);
            writeFile.Close();
        }
    }
    private void IncreaseAttemptTry(int rowRemove, int colRemove)
    {
        int attemptsAllowed = 4;
        string fileToWrite = "";
        //Reads through the file and creates a new file
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            string line = "";
            int row = 0;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                row++;
                if (row != rowRemove)
                {
                    fileToWrite = fileToWrite + line;
                }
                else
                {
                    while (i != colRemove)
                    {
                        fileToWrite = fileToWrite + line[i];
                        i++;
                    }
                    if (i == colRemove)
                    {
                        int temp = (int)Char.GetNumericValue(line[i]);
                        temp = temp + 1;
                        if (temp > (attemptsAllowed - 1))
                        {
                            temp = attemptsAllowed;
                        }
                        fileToWrite = fileToWrite + temp.ToString();
                    }
                }
                fileToWrite = fileToWrite + '\n';
            }
            reader.Close();
        }
        //Del file
        File.Delete(@ioFile);
        //recreate file
        FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        file.Close();
        //write fileToWrite to file
        using (StreamWriter writeFile = File.AppendText(@ioFile))
        {
            writeFile.Write(fileToWrite);
            writeFile.Close();
        }
    }
    private void ResetAttemptTry(int rowRemove, int colRemove)
    {
        string fileToWrite = "";
        //Reads through the file and creates a new file
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            string line = "";
            int row = 0;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                row++;

                if (row != rowRemove)
                {
                    fileToWrite = fileToWrite + line;
                }
                else
                {
                    while (i != colRemove)
                    {
                        fileToWrite = fileToWrite + line[i];
                        i++;
                    }
                    if (i == colRemove)
                    {
                        fileToWrite = fileToWrite + "0";
                    }
                }
                fileToWrite = fileToWrite + '\n';
            }
            reader.Close();
        }
        //Del file
        File.Delete(@ioFile);
        //recreate file
        FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        file.Close();
        //write fileToWrite to file
        using (StreamWriter writeFile = File.AppendText(@ioFile))
        {
            writeFile.Write(fileToWrite);
            writeFile.Close();
        }
    }

    private void ChangeFilePassword(string username, string newPassword)
    {
        bool admin = isAdmin(username);
        DelUser(username);
        AddUser(username, newPassword, admin);
    }
         
}