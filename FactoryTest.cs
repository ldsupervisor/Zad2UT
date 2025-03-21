using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class PlanPieczeniaTests
{
    [TestMethod]
    public void DodajDwaRozneCzasy_BezMoka()
    {
        // Arrange
        var planPieczenia = new PlanPieczenia();
        var fabrykaCiastaCzekoladowego = new FabrykaCiastaCzekoladowego();
        var fabrykaCiastaJabłkowego = new FabrykaCiastaJabłkowego();

        // Act
        planPieczenia.DodajCiasto(fabrykaCiastaCzekoladowego);
        planPieczenia.DodajCiasto(fabrykaCiastaJabłkowego);

        // Assert
        Assert.AreEqual(2, planPieczenia.Count(), "Ilość ciast w planie powinna być równa 2");
    }


    [TestMethod]
    public void WyświetlPlan_WyświetlaInformacjeOCiastach()
    {
        // Arrange
        var planPieczenia = new PlanPieczenia();
        var fabrykaCiasta1 = new FabrykaCiastaJabłkowego();
        var fabrykaCiasta2 = new FabrykaCiastaCzekoladowego();
        planPieczenia.DodajCiasto(fabrykaCiasta1);
        planPieczenia.DodajCiasto(fabrykaCiasta2);

        // Act
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            planPieczenia.WyświetlPlan();
            string result = sw.ToString();

            // Assert
            StringAssert.Contains(result, "Jabłkowe");
            StringAssert.Contains(result, "Czekoladowe");
            StringAssert.Contains(result, "Składniki: Jabłka, Cynamon, Mąka, Cukier");
            StringAssert.Contains(result, "Czekolada", "Mąka", "Jajka", "Masło");
        }
    }
}
