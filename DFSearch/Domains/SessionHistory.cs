using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DFSearch.Domains
{
    public class SessionHistory
    {
        public List<Session> sessionHistory = new List<Session>();
        public Session currentSession;

        public void StartNewSession(string userName)
        {
            currentSession = new Session
            {
                UserName = userName,
                StartTime = DateTime.Now
            };
            sessionHistory.Add(currentSession);
        }

        public void EndCurrentSession()
        {
            if (currentSession != null)
            {
                currentSession.EndTime = DateTime.Now;
            }
        }
        public void LoadSessionHistory()
        {
            string filePath = "sessionHistory.json";

            if (!File.Exists(filePath))
            {
                
                File.WriteAllText(filePath, "[]");
            }

            
            var json = File.ReadAllText(filePath);
            sessionHistory = JsonSerializer.Deserialize<List<Session>>(json) ?? new List<Session>();
        }
        public void SaveSessionHistory()
        {
            var json = JsonSerializer.Serialize(sessionHistory, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("sessionHistory.json", json);
        }
    }
}
