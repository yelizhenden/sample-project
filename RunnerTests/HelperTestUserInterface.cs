namespace Helpers
{
    

    public class TestUserInterface : IUserInterface
    {
        int _expectedWriteWarningRequestsIndex;
        int _expectedWriteMessageRequestsIndex;
        int _expectedReadRequestsIndex;

        List<string> _expectedWriteWarningRequests;
        List<string> _expectedWriteMessageRequests;
        List<Tuple<string, string>> _expectedReadRequests;

        TestUserInterface(List<Tuple<string,string>> expectedReadRequests,
        List<string> expectedWriteMessageRequests,
        List<string> expectedWriteWarningRequests)
        {
            _expectedReadRequests = expectedReadRequests;
            _expectedWriteMessageRequests = expectedWriteMessageRequests;
            _expectedWriteWarningRequests = expectedWriteWarningRequests;
        }
        public void WriteWarning(string message)
        {
            Assert.IsTrue(_expectedWriteWarningRequestsIndex < _expectedWriteWarningRequests.Count,
                "Received too many command write warning requests.");

            Assert.AreEqual(_expectedWriteWarningRequests[_expectedWriteWarningRequestsIndex++], message,
                "Received unexpected command write warning message");
        }

        public void WriteMessage(string message)
        {
            Assert.IsTrue(_expectedWriteMessageRequestsIndex < _expectedWriteMessageRequests.Count,
                "Received too many command write warning requests.");

            Assert.AreEqual(_expectedWriteMessageRequests[_expectedWriteMessageRequestsIndex++], message,
                "Received unexpected command write warning message");
        }

       public string ReadValue(string message)
        {
            Assert.IsTrue(_expectedReadRequestsIndex < _expectedReadRequests.Count,
                "Received too many command read requests.");
                    
            Assert.AreEqual(_expectedReadRequests[_expectedReadRequestsIndex].Item1, message, 
                "Received unexpected command read message");

            return _expectedReadRequests[_expectedReadRequestsIndex++].Item2;
        }

        public void Validate()
        {
            Assert.IsTrue(_expectedReadRequestsIndex == _expectedReadRequests.Count, 
                  "Not all read requests were performed.");

            Assert.IsTrue(_expectedWriteMessageRequestsIndex == _expectedWriteMessageRequests.Count, 
                  "Not all write requests were performed.");
            Assert.IsTrue(_expectedWriteWarningRequestsIndex == _expectedWriteWarningRequests.Count, 
                  "Not all warning requests were performed.");
        }
    }
}