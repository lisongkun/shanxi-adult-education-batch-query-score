using System;

namespace ShanxiAdultEducationBatchQueryScore.Vo
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string TicketNo { get; set; }
        public string CandidateName { get; set; }
        public string ErrorMessage { get; set; }
        public string SavedFilePath { get; set; }

        public static LoginResult Fail(string message)
        {
            return new LoginResult
            {
                Success = false,
                ErrorMessage = message ?? ""
            };
        }

        public static LoginResult Ok(string ticketNo, string candidateName, string savedFilePath)
        {
            return new LoginResult
            {
                Success = true,
                TicketNo = ticketNo,
                CandidateName = candidateName,
                SavedFilePath = savedFilePath
            };
        }
    }
}
