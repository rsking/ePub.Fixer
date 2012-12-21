namespace RossKing.EPub.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFullTextChecker
    {
        bool CheckText(string fullText);
    }
}
