﻿/*
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

namespace ModelValidatorEAAddin
{
    public class EAConsoleLogger
    {
        private static readonly Lazy<EAConsoleLogger> logger = new Lazy<EAConsoleLogger>(() => new EAConsoleLogger());
        public static EAConsoleLogger Instance => logger.Value;
        private EAConsoleLogger() { }
        public Repository Repository { get; set; }

        public void Error(string message)
        {
            Repository.EnsureOutputVisible("System");
            Repository.WriteOutput("System", $" {DateTime.Now:HH:mm:ss} [ ERROR ] {message}", 0);
        }

        public void Warning(string message)
        {
            Repository.EnsureOutputVisible("System");
            Repository.WriteOutput("System", $" {DateTime.Now:HH:mm:ss}[ WARNING ] {message}", 0);
        }

        public void Info(string message)
        {
            Repository.EnsureOutputVisible("System");
            Repository.WriteOutput("System", $" {DateTime.Now:HH:mm:ss} [ INFO ] {message}", 0);
        }

        public void Debug(string message)
        {
            Repository.EnsureOutputVisible("System");
            Repository.WriteOutput("System", $" {DateTime.Now:HH:mm:ss} [ DEBUG ] {message}", 0);
        }
    }
}
