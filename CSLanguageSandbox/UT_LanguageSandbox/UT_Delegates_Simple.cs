using System;
using NUnit.Framework;
using CSLanguageSandbox;


namespace UT_LanguageSandbox
{
    [TestFixture]
    public class UT_Delegates_WithAnonymousMethods
    {        
        [Test]
        public void When_UsingEmailDelegate_Should_SendToEmail()
        {
            Document doc = new Document();
            doc.Text = "This is the Document's text";

            var emailServer = new EmailServer();
            var emailDelegate = new Document.SendDocument(emailServer.SendEmail);
            Assert.AreEqual("Sending email", doc.SendAndReport(emailDelegate));
            
        }

        [Test]
        public void When_UsingBlogDelegate_Should_PostToBlog()
        {
            Document doc = new Document();
            doc.Text = "This is the Document's text";
                        
            var blogPoster = new BlogPoster();
            var blogDelegate = new Document.SendDocument(blogPoster.PostBlog);
            Assert.AreEqual("Sending post", doc.SendAndReport(blogDelegate));

        }

        [Test]
        public void When_DelegatePointToAListOfFunctions_Should_ExecuteThemAllInOrderOnOriginalInput()
        {
            MyDouble num = new MyDouble(9);

            MyDouble.NumberOperation operations = new MyDouble.NumberOperation(MathUtilities.SquareRoot);
            operations += MathUtilities.AdvanceNumber;
            operations += MathUtilities.Square;

            // Note: all functions will execute on the original parameter! They will not be chained to execute the next on the 
            //       previous' function output.             
            //       In this example, this.value is equal to 9 when the delegate is called. Therefore, all functions will execute on the number 9.
            //       and at the end of the run, num.value will hold the result of the last calculation (Square) which is equal to 81.0
            num.ExecuteOperations(operations);
            Assert.AreEqual(81.0, num.value);

            operations = MathUtilities.Square;
            operations += MathUtilities.SquareRoot;
            operations += MathUtilities.AdvanceNumber;

            num.ExecuteOperations(operations);
            Assert.AreEqual(82.0, num.value);


        }

        [Test]
        public void Should_AllowUsingBuiltInDelegates()
        {
            // Note: this code will not work with var
            Func<double,double> myDelegate = MathUtilities.Square;
            myDelegate += MathUtilities.SquareRoot;
            myDelegate += MathUtilities.AdvanceNumber;

            var result = myDelegate(5);
            Assert.AreEqual(6.0, result);
        }
    }
   
}
