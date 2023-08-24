/*
 *  Copyright 2023 Gergely Ulicska
 *  
 *  See the README file(s) distributed with this work for additional
 *  information regarding copyright ownership and contributors.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */
using EA;
using System;
using System.Security;

namespace ModelValidatorConsoleApplication
{
    internal class DatabaseConnector
    {
        private Repository repository;
        // open connection to Enterprise Architect
        public Repository OpenConnection(string connString, string username = null, string password = null)
        {
            try
            {
                repository = new Repository
                {
                    SuppressSecurityDialog = true
                };

                if (username == null)
                {
                    SystemConsoleLogger.Instance.Info("Please, enter your username:");
                    Console.Write(" > ");
                    username = Console.ReadLine();
                }

                if (password == null)
                {
                    SystemConsoleLogger.Instance.Info("Please, enter your password:");
                    Console.Write(" > ");
                    password = ReadPassword().ToString();
                }

                if (repository.OpenFile2(connString, username, password) == false)
                {
                    SystemConsoleLogger.Instance.Error("Unsuccessful login.");
                    return null;
                }
                SystemConsoleLogger.Instance.Info("Successful login.");
                return repository;
            }
            catch (Exception exc)
            {
                SystemConsoleLogger.Instance.Error(exc.Message);
                return null;
            }
        }

        private SecureString ReadPassword()
        {
            SecureString password = new SecureString();
            ConsoleKeyInfo nextKey = Console.ReadKey(true);

            while (nextKey.Key != ConsoleKey.Enter)
            {
                if (nextKey.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.RemoveAt(password.Length - 1);
                        // erase the last * as well
                        Console.Write(nextKey.KeyChar);
                        Console.Write(" ");
                        Console.Write(nextKey.KeyChar);
                    }
                }
                else
                {
                    password.AppendChar(nextKey.KeyChar);
                    Console.Write("*");
                }
                nextKey = Console.ReadKey(true);
            }
            password.MakeReadOnly();
            return password;
        }

        ~DatabaseConnector()
        {
            repository.Exit();
            SystemConsoleLogger.Instance.Info("Connection closed");
        }
    }
}
