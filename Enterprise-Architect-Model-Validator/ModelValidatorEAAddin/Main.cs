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
using System;
using EA;

namespace ModelValidatorEAAddin
{
    public class Main
    {
        ModelValidatorUserControl addinDialog;

        private void LoadAddin(Repository Repository)
        {
            addinDialog = Repository.AddWindow("ModelValidator", "ModelValidatorEAAddin.ModelValidatorUserControl") as ModelValidatorUserControl;
            addinDialog.Repository = Repository;
            addinDialog.CreateModelValidator();
        }

        public string EA_Connect(Repository Repository)
        {
            return "ModelValidator";
        }

        public virtual void EA_Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void EA_OnContextItemChanged(Repository Repository, string GUID, ObjectType ot)
        {
            if (addinDialog == null)
            {
                LoadAddin(Repository);
            }
        }
    }
}
