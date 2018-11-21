using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace I_have_a_plan.Models
{
    public class JSONSerializer
    {
        public  IFileService file;
        readonly string projectFileName = "projectList.json";
        readonly string scheduleFileName = "schedule.json";

        public JSONSerializer()
        {
            file = DependencyService.Get<IFileService>();
        }

        public async System.Threading.Tasks.Task SaveProjectsToJsonAsync(List<Project> projects)
        {
            
            string text = Newtonsoft.Json.JsonConvert.SerializeObject(projects);
            await file.WriteToFileAsync(projectFileName, text);
        }

        public async System.Threading.Tasks.Task SaveScheduleToJson(Dictionary<Int32,DateTime> schedule)
        {
            string text = Newtonsoft.Json.JsonConvert.SerializeObject(schedule);
            await file.WriteToFileAsync(scheduleFileName, text);
        }

        public Dictionary<Int32, DateTime> LoadScheduleFromJson()
        {
            bool fileExisting = false;
            System.Threading.Tasks.Task.Run(async () => { fileExisting = await file.IsFileExistAsync(scheduleFileName); }).Wait();
            //check the file is existing
            if (fileExisting)
            {
                string text = "";
                System.Threading.Tasks.Task.Run(async () => { text = await file.ReadFromFileAsync(projectFileName); }).Wait();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<Int32, DateTime>>(text);
            }
            else
                return new Dictionary<Int32, DateTime>();
            //throw new NotImplementedException();
        }

        public List<Project> LoadProjectsFromJson()
        {
            bool fileExisting = false;
            System.Threading.Tasks.Task.Run(async () => { fileExisting = await file.IsFileExistAsync(projectFileName); }).Wait();
            //check the file is existing
            if (fileExisting)
            {
                string text = "";
                System.Threading.Tasks.Task.Run(async () => { text = await file.ReadFromFileAsync(projectFileName); }).Wait();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Project>>(text);
            }
            else
                return new List<Project>();
            //create new list
        }

        public async System.Threading.Tasks.Task<List<Project>> LoadProjectsFromJsonAsync()
        {
            // Asynchronously load the list
            if (await file.IsFileExistAsync(projectFileName)) { 
                string text = await file.ReadFromFileAsync(projectFileName);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Project>>(text);
            }
            else
                return new List<Project>();

        }

    }
}
