using System;

namespace ArvoreGenealogica
{
    class Program
    {
        static void Main(string[] args)
        {
            var lily = new Pessoa("Lily", new Pessoa("Wilhelm"));
            var opa = new Pessoa("Opa", new Pessoa("Oma"));
            var reinhold = new Pessoa("Reinhold", new Pessoa("Sonia"));
            var christian = new Pessoa("Christian", new Pessoa("Mônica"));
            var oscar = new Pessoa("Oscar");
            var lorena = new Pessoa("Lorena");
            var gabriel = new Pessoa("Gabriel");
            var sabine = new Pessoa("Sabine");

            var wilma = new Pessoa("Wilma", new Pessoa("Rodolfo"));
            var ricardo = new Pessoa("Ricardo", new Pessoa("Debora"));
            var rodrigo = new Pessoa("Rodrigo");

            var sigrid = new Pessoa("Sigrid", new Pessoa("Peter"));
            var martin = new Pessoa("Martin", new Pessoa("Carla"));

            var nicolas = new Pessoa("Nicolas");
            var thomas = new Pessoa("Thomas");
            var claudia = new Pessoa("Claudia");

            lily.AddFilho(opa);

            opa.AddFilho(reinhold);
            opa.AddFilho(wilma);
            opa.AddFilho(sigrid);

            reinhold.AddFilho(christian);
            reinhold.AddFilho(gabriel);
            reinhold.AddFilho(sabine);

            christian.AddFilho(oscar);
            christian.AddFilho(lorena);

            wilma.AddFilho(ricardo);
            wilma.AddFilho(rodrigo);

            sigrid.AddFilho(martin);
            sigrid.AddFilho(thomas);
            sigrid.AddFilho(claudia);

            martin.AddFilho(nicolas);

            lily.Imprimir();
        }
    }
}
