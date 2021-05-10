using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    class Token
    {
        public string lexema;
        public string nombre;

        public Token(string lexema, string nombre)
        {
            this.lexema = lexema;
            this.nombre = nombre;
        }
    }

    class Tokens
    {
        private List<string> palabras = new List<string>();
        public List<Token> tokens = new List<Token>();
        List<string> simbolosEspeciales = new List<string> { "+", "-", "*", "/", "=", "<", ">", "(", ")", ";", ":=" };
        List<string> palabrasReservadas = new List<string> { "if", "then", "else", "end", "repeat", "until", "read", "write" };
        string lexema = "";

        public Tokens(List<string> pedazos)
        {
            //Elimina los espacios de cada parte del código que viene en chars
            palabras = pedazos;
        }

        public void clasificaTokens()
        {
            while (palabras.Count() > 0)
            {
                int i = 0;
                string palabra = palabras.First();

                if (isSimboloEspecial(palabra))
                    agregaToken(new Token(palabra, lexema));
                else if(buscaPalabraReservada(palabra))
                    agregaToken(new Token(palabra, lexema));
                else
                {
                    agregaToken(new Token(palabra, lexema));
                    palabras.Remove(palabra);
                }
                lexema = "";
            }
        }

        private bool buscaPalabraReservada(string cad)
        {
            bool verifica = palabrasReservadas.Exists(res => res.Equals(cad));
            if (verifica)
            {
                lexema = palabrasReservadas.Find(res => res.Equals(cad));
                palabras.Remove(cad);
            }
            return verifica;
        }

        private bool isSimboloEspecial(string simbolo)
        {
            bool verifica = simbolosEspeciales.Exists(simb => simb.Equals(simbolo.ToString()));
            if (verifica)
            {
                lexema = simbolosEspeciales.Find(simb => simb.Equals(simbolo.ToString()));
                palabras.Remove(simbolo);
            }
            return verifica;
        }

        private void agregaToken(Token tk)
        {
            bool verifica = tokens.Exists(t => tk.nombre.Equals(t.nombre) && tk.lexema.Equals(t.lexema));
            if (!verifica)
                tokens.Add(tk);
        }
        public List<Token> getTokensSinClasificar()
        {
            return tokens.FindAll(x => x.nombre.Equals(""));
        }
    }
}
