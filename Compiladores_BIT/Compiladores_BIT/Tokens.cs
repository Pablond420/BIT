using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    /// <summary>
    /// Clase que describe un token con nombre y lexema
    /// </summary>
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

    /// <summary>
    /// Clase para realizar todos los métodos en tokens para identificar el tipo
    /// </summary>
    class Tokens
    {
        private List<string> palabras = new List<string>();
        public List<Token> tokens = new List<Token>();
        List<string> simbolosEspeciales = new List<string> { "+", "-", "*", "/", "=", "<", ">", "(", ")", ";", ":=" };
        List<string> palabrasReservadas = new List<string> { "if", "then", "else", "end", "repeat", "until", "read", "write" };
        string lexema = "";

        public Tokens(List<string> pedazos)
        {
            palabras = pedazos;
        }

        /// <summary>
        /// Funcion que controla la iteracion entre cada token y verifica el tipo de token para despues agregarlo a una lista global de tokens
        /// </summary>
        public void clasificaTokens()
        {
            //Mientras aun existan palabras o tokens que clasificar
            while (palabras.Count() > 0)
            {
                //Extrae la primer palabra
                string palabra = palabras.First();

                //Si esta palabra es un simbolo especial
                if (isSimboloEspecial(palabra))
                    agregaToken(new Token(palabra, lexema)); //Agrega la palabra con el nombre y lexema del simbolo especial encontrado
                else if(buscaPalabraReservada(palabra)) //Si la palabra es una palabra reservada
                    agregaToken(new Token(palabra, lexema)); //Agrega la palabra con el nombre y lexema de la palabra reservada
                else
                {
                    //Si no, entonces se agrega el token y es un identificador o un numero que despues se evaluará con un AFD
                    agregaToken(new Token(palabra, lexema));
                    //Elimina la palabra que se acaba de agregar a la lista de tokens
                    palabras.Remove(palabra);
                }
                //Reinicia el lexema
                lexema = "";
            }
        }

        /// <summary>
        /// Funcion para determinar si una cadena pertenece a las palabras reservadas
        /// </summary>
        /// <param name="cad">La cadena que se evalua</param>
        /// <returns>Booleano que indica si pertenece o no a las palabras reservadas</returns>
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

        /// <summary>
        /// Funcion para determinar si una cadena pertenece a los simbolos especiales
        /// </summary>
        /// <param name="simbolo">El simbolo que se evalua</param>
        /// <returns>Booleano que indica si pertenece o no a los simbolos especiales</returns>
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

        /// <summary>
        /// Agrega nuevos tokens verificando que no exista un token igual en la lista
        /// </summary>
        /// <param name="tk">El token que se quiere agregar</param>
        private void agregaToken(Token tk)
        {
            bool verifica = tokens.Exists(t => tk.nombre.Equals(t.nombre) && tk.lexema.Equals(t.lexema));
            if (!verifica)
                tokens.Add(tk);
        }

        /// <summary>
        /// Obtiene todos los tokens que no se pudieron clasificar como simbolos especiales o palabras reservadas
        /// </summary>
        /// <returns>Lista con los tokens que pueden ser identificador o numero o presentar un error léxico</returns>
        public List<Token> getTokensSinClasificar()
        {
            return tokens.FindAll(x => x.nombre.Equals(""));
        }
    }
}
