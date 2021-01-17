using RomanApp.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanApp.Controller.Utils
{
    public class HelpTopicRelations
    {

        public static List<HelpTopic> GetRelatedTopics(HelpTopic topic) 
        {
            List<HelpTopic> retval = null;

            retval = new List<HelpTopic>();
            if(topic == HelpTopic.Overview)
            {
                retval.Add(HelpTopic.SheetOverview);
                retval.Add(HelpTopic.Settings);
            }
            else
            {
                retval.Add(HelpTopic.Overview);
                switch (topic)
                {
                    case HelpTopic.Overview:
                        break;
                    case HelpTopic.SheetOverview:
                        retval.Add(HelpTopic.SheetInputOverview);
                        retval.Add(HelpTopic.SheetOutcomeOverview);
                        break;
                    case HelpTopic.SheetInputOverview:
                        retval.Add(HelpTopic.SheetOverview);
                        retval.Add(HelpTopic.SheetOutcomeOverview);
                        break;
                    case HelpTopic.SheetOutcomeOverview:
                        retval.Add(HelpTopic.SheetOverview);
                        retval.Add(HelpTopic.SheetInputOverview);
                        break;
                    case HelpTopic.Settings:
                        break;
                }
            }

            return retval;
        }

    }
}
