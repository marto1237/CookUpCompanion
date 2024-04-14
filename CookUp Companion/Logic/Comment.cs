using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUp_Companion_Classes
{
    public class Comment
    {
       
        public User rater { get; private set; }
        public bool userReaction{ get; private set; }
        public string comment { get; private set; }
        public DateTime timestamp { get; private set; }
        public  Comment(User user, bool userReaction, string userComment, DateTime timestamp)
        {
            rater = user;
            this.userReaction = userReaction;
            comment = userComment;
            this.timestamp = timestamp;
        }
    }
    
}
