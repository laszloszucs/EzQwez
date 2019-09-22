using System.Collections.Generic;

namespace EzQwez
{
    public class Tenses : Category
    {
        public Tenses() : base("I", "Igeidők")
        {
            Pool = new List<Qwez>
            {
                new Qwez("He has been eating a banana for 5 minutes.", "Már öt perce banánt eszik."),
                new Qwez("He has been eating a banana since 8 this morning.", "Reggel 8 óta banánt eszik."),
                new Qwez("Have you eaten the banana yet?", "Megetted már a banánt?"),
                new Qwez("I have already eaten the banana.", "Már megettem a banánt."),
                new Qwez("I haven’t eaten the banana yet.", "Még nem ettem meg a banánt."),
                new Qwez("He is eating a banana now.", "Éppen egy banánt eszik. (Épp banánt eszik.)"),
                new Qwez("He eats a banana every day.", "Minden nap eszik egy banánt."),
                new Qwez("When I entered, he had been eating a banana for 20 minutes.", "Mikor bementem, már 20 perce banánt evett."),
                new Qwez("By the time I arrived, he had eaten the banana.", "Mire megjöttem már megette a banánt."),
                new Qwez("When I arrived, he was eating a banana. / He was eating a banana when I arrived.", "Épp banánt evett amikor megjöttem."),
                new Qwez("He ate a banana yesterday. Yesterday, he ate a banana.", "Tegnap evett egy banánt."),
                new Qwez("When I entered, he will have been eating a banana for 20 minutes.", "Mikor bemegyek, már 20 perce banánt fog enni."),
                new Qwez("By the time I get there, he will have eaten the banana.", "Mire odaérek, már rég megeszi/megette a banánt."),
                new Qwez("He will be eating a banana when I get there.", "Épp banánt fog enni, mikor odaérek."),
                new Qwez("He will eat a banana tomorrow. / Tomorrow he will eat a banana.", "Holnap eszik majd egy banánt.")
            };
        }
    }
}
