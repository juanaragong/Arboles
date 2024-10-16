using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Drawing.Printing;

namespace Arboles
{
    internal class Nodo_Arbol
    {
        public int info;
        public Nodo_Arbol Izquierdo;
        public Nodo_Arbol Derecho;
        public Nodo_Arbol Padre;
        public int altura;
        public int nivel;
        public Rectangle nodo;

        private Arbol_Binario arbol;

        public Nodo_Arbol() { }

        public Arbol_Binario Arbol
        { 
          get { return arbol; }
          set { arbol = value; }
        }

        public Nodo_Arbol(int nueva_info, Nodo_Arbol izquierdo, Nodo_Arbol derecho, Nodo_Arbol padre)
        { 
            info=nueva_info;
            Izquierdo = izquierdo;
            Derecho=derecho;
            Padre=padre;
            altura=0;
        }

        public Nodo_Arbol Insertar(int x, Nodo_Arbol t, int level)
        {
            if (t == null)
            {
                t = new Nodo_Arbol(x, null, null, null);
                t.nivel = level;
            }

            else if (x < t.info)
            {
                level++;
                t.Izquierdo = Insertar(x, t.Izquierdo, level);
            }
            else if (x>t.info)
            {
                level++;
                t.Derecho = Insertar(x, t.Derecho, level);
            }
            else
            {
                MessageBox.Show("Dato Existente en el Arbol", "Error de ingreso");
            }

            return t;
        }

        private static int Alturas(Nodo_Arbol t)
        {
            return t == null ? -1 : t.altura;
        }

        public void Eliminar(int x, ref Nodo_Arbol t)
        {
            if (t != null)
            {
                if (x < t.info)
                {
                    Eliminar(x, ref t.Izquierdo);
                }
                else
                {
                    if (x > t.info)
                    {
                        Eliminar(x, ref t.Derecho);
                    }
                    else
                    {
                        Nodo_Arbol nodoEliminiar = t;
                        if (nodoEliminiar.Derecho == null)
                        {
                            t = nodoEliminiar.Izquierdo;
                        }
                        else
                        {
                            if (nodoEliminiar.Izquierdo == null)
                            {
                                t = nodoEliminiar.Derecho;
                            }
                            else
                            {
                                if (Alturas(t.Izquierdo) - Alturas(t.Derecho) > 0)
                                {
                                    Nodo_Arbol AuxiliarNodo = null;
                                    Nodo_Arbol Auxiliar = t.Izquierdo;
                                    bool bandera = false;

                                    while (Auxiliar.Derecho != null)
                                    {
                                        AuxiliarNodo = Auxiliar;
                                        Auxiliar = AuxiliarNodo.Derecho;
                                        bandera = true;
                                    }
                                    t.info = Auxiliar.info;
                                    nodoEliminiar = Auxiliar;

                                    if (bandera == true)
                                    {
                                        AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
                                    }
                                    else
                                    {
                                        t.Izquierdo = Auxiliar.Izquierdo;
                                    }
                                }
                            }
                        }
                    }
                }
            }


            else
            {
                MessageBox.Show("El nodo no existe en el arbol");
            }
        
        }

        public void buscar(int x, Nodo_Arbol t)
        {
            if (t != null)
            {
                if (x < t.info)
                {
                    buscar(x, t.Izquierdo);
                }
                else
                {
                    if (x > t.info)
                    {
                        buscar(x, t.Derecho);
                    }
                }
            }
            else
                MessageBox.Show("Nodo no encontrado en el arbol");
        }


        private const int Radio = 30;
        private const int DistanciaH = 80;
        private const int DistanciaV = 10;

        private int CoordenadaX;
        private int CoordenadaY;

        public void PosicionNodo(ref int xmin, int ymin)
        {
            int aux1, aux2;
            CoordenadaY = (int)(ymin + Radio / 2);

            if (Izquierdo != null)
            {
                Izquierdo.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }

            if ((Izquierdo != null) && (Derecho != null))
            {
                xmin += DistanciaH;
            }

            if (Derecho != null)
            {
                Derecho.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }

            if (Izquierdo != null && Derecho != null)
                CoordenadaX = (int)((Izquierdo.CoordenadaX + Derecho.CoordenadaY) / 2);
            else if (Izquierdo != null)
            {
                aux1 = Izquierdo.CoordenadaX;
                Izquierdo.CoordenadaX = CoordenadaX - 80;
                CoordenadaX = aux1;
            }
            else if (Derecho != null)
            {
                aux2 = Derecho.CoordenadaX;
                Derecho.CoordenadaX = CoordenadaX + 80;
                CoordenadaX = aux2;
            }
            else 
            {
                CoordenadaX = (int)(xmin + Radio / 2);
                xmin +=Radio;
            }
           
        }

        public void DibujarRamas(Graphics grafo, Pen Lapiz)
        {
            if (Izquierdo != null)
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY, Izquierdo.CoordenadaX, Izquierdo.CoordenadaY);
                Izquierdo.DibujarRamas(grafo, Lapiz);
            }

            if (Derecho != null)
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY, Derecho.CoordenadaX, Derecho.CoordenadaY);
                Derecho.DibujarRamas(grafo, Lapiz);
            }
        }


        public void DibujarNodo(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
           
            Rectangle rect = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY - Radio / 2), Radio, Radio);
                

            grafo.FillEllipse(encuentro, rect);
            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);


            StringFormat formato = new StringFormat();

            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(info.ToString(), fuente, RellenoFuente, CoordenadaX, CoordenadaY, formato);


            if (Izquierdo != null)
            {
                Izquierdo.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
            if (Derecho != null)
            {
                Derecho.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
            }
        }


        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz)
        {
            Rectangle rect = new Rectangle((int)(CoordenadaX-Radio/2),(int)(CoordenadaY-Radio/2),Radio,Radio);
            //prueba = new Rectangle((int)(CoordenadaX - Radio / 2), (int)(CoordenadaY - Radio / 2), Radio, Radio);

            grafo.FillEllipse(Relleno, rect);
            grafo.DrawEllipse(Lapiz, rect);

            StringFormat formato=new StringFormat();

            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;
            grafo.DrawString(info.ToString(), fuente, RellenoFuente, CoordenadaX, CoordenadaY, formato);
        }
    }
}
