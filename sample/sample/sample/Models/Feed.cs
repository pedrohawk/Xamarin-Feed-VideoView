using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class Feed : BaseModel
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Interactions")]
        public IEnumerable<Interaction> Interactions { get; set; }

        [JsonProperty("Media")]
        public Media Media { get; set; }

        [JsonProperty("CreateDate")]
        public DateTimeOffset CreateDate { get; set; }

        public string PostedAt
        {
            get
            {
                if (CreateDate == null)
                {
                    return "";
                }

                var datenow = DateTimeOffset.Now;
                var diffMinutes = Math.Abs((CreateDate - datenow).TotalMinutes);
                if (diffMinutes < 60)
                {
                    return (int)diffMinutes + "m ago";
                }

                var diffHours = Math.Abs((CreateDate - datenow).TotalHours);
                if (diffHours < 24)
                {
                    return (int)diffHours + "h ago";
                }

                var diffDays = Math.Abs((CreateDate - datenow).TotalDays);
                return (int)diffDays + "d ago";
            }
        }

        public int InteractionsLikes
        {
            get
            {
                var counter = 0;

                if (Interactions != null && Interactions.Count() > 0)
                {
                    foreach(Interaction i in Interactions)
                    {
                        //Assuming Likes is Type=0
                        if (i.Type == 0)
                        {
                            counter++;
                        }
                    }
                }

                return counter;
            }
        }

        public int InteractionsShares
        {
            get
            {
                var counter = 0;

                if (Interactions != null && Interactions.Count() > 0)
                {
                    foreach (Interaction i in Interactions)
                    {
                        //Assuming shares is Type=1
                        if (i.Type == 1)
                        {
                            counter++;
                        }
                    }
                }

                return counter;
            }
        }

        private int _autoStop;
        public int AutoStop
        {
            get
            {
                return _autoStop;
            }
            set
            {
                _autoStop = value;
                OnPropertyChanged(nameof(AutoStop));
            }
        }

        private int _timeleft;
        public int Timeleft
        {
            get { return _timeleft; }
            set { _timeleft = value;
                OnPropertyChanged(nameof(Timeleft));
            }
        }

        private bool _showTimeLeft;
        public bool ShowTimeleft
        {
            get { return _showTimeLeft; }
            set { _showTimeLeft = value;
                OnPropertyChanged(nameof(ShowTimeleft));

            }
        }
    }
}
