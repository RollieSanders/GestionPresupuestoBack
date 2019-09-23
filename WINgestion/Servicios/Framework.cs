using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace WINgestion
{
    public class Framework
    {

         public string TraerDescripcionUbicacionGeografica_DataTable(DataTable dt, string strValorBuscado)
        {

            string strResult = "";

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToString(row[0]) == strValorBuscado)
                    {
                        strResult = Convert.ToString(row[1]).TrimEnd() + " " +
                                    Convert.ToString(row[2]).TrimEnd() + " " +
                                    Convert.ToString(row[3]).TrimEnd();
                        break;
                    }
                }
            }


            return strResult;
        }

        public string TraePeriodoAnterior(string AnoMes)
        {

            string anomesr = "";
            int numeromes = 0;
            int numeroano = 0;
            char pad = '0';

            numeromes = Convert.ToInt32(AnoMes.TrimEnd().Substring(4, 2));
            numeroano = Convert.ToInt32(AnoMes.TrimEnd().Substring(0, 4));

            if (numeromes > 1)
            {
                numeromes = numeromes - 1;
            }
            else
            {
                numeromes = 12;
                numeroano = numeroano - 1;
            }

            anomesr = Convert.ToString(numeroano) +
                      Convert.ToString(numeromes).TrimEnd().PadLeft(2, pad);

            return anomesr;

        }

        public string TraeNombreMes(string Mes)
        {
            string lcResult = "";
            string lcMeses = "";
            int lnMes = 0;

            lnMes = Convert.ToInt32(Mes);
            lcMeses = "ENERO    FEBRERO  MARZO    ABRIL    " +
                      "MAYO     JUNIO    JULIO    AGOSTO   " +
                      "SETIEMBREOCTUBRE  NOVIEMBREDICIEMBRE";



            lcResult = lcMeses.Substring((9 * (lnMes - 1)), 9);
            return lcResult;
        }

        public string TraerDescripcion_DataTable(DataTable dt,
                                                   int intCampoBusqueda,
                                                   int intCampoResultante,
                                                   string strValorBuscado)
        {
            string strResult = "";

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if ( !string.IsNullOrEmpty( strValorBuscado ))
                    {
                        if (Convert.ToString(row[intCampoBusqueda]).TrimEnd() == strValorBuscado.TrimEnd())
                        {
                            strResult = Convert.ToString(row[intCampoResultante]).TrimEnd();
                            break;
                        }

                    }

                }
            }

            return strResult;
        }

        public void EstadoAcceso()
        {

            if (IsConnectionAvailable() == true)
            {

                if (Ping("198.150.0.53", 10) == true)
                {
                    MyStuff.UsaWCF = false;
                }
                else
                {
                    MyStuff.UsaWCF = true;
                }

            }
            else
            {
                MyStuff.UsaWCF = false;
            }

        }

        public bool IsConnectionAvailable()
        {
            System.Uri objUrl = new System.Uri("http://www.amsac.com.pe/");
            System.Net.WebRequest objWebReq;
            objWebReq = System.Net.WebRequest.Create(objUrl);
            System.Net.WebResponse objResp;
            try
            {
                objResp = objWebReq.GetResponse();
                objResp.Close();
                objWebReq = null;
                return true;
            }
            catch
            {
                objWebReq = null;
                return false;
            }
        }

        public bool Ping(string strIp, int intTiempoEspera)
        {
            Ping Pings = new Ping();
            int timeout = intTiempoEspera;
            bool blnRetorno = false;
            try
            {
                if (Pings.Send(strIp, timeout).Status == IPStatus.Success) ;
                {
                    blnRetorno = true;
                }
            }
            catch
            {
                blnRetorno = false;
            }
            return blnRetorno;
        }

        public bool IsConnectionLan(string strIP, int intPuerto)
        {
            if (intPuerto != 0)
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


                s.Connect(strIP, intPuerto);

                if (!s.Connected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


        #region Dll Imports
        [DllImport("Netapi32", CharSet = CharSet.Auto, SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
        public static extern int NetServerEnum(string ServerNane,
                                                int dwLevel,
                                                ref IntPtr pBuf,
                                                int dwPrefMaxLen,
                                                out int dwEntriesRead,
                                                out int dwTotalEntries,
                                                int dwServerType,
                                                string domain,
                                                out int dwResumeHandle
                                              );
        [DllImport("Netapi32", SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
        public static extern int NetApiBufferFree(
        IntPtr pBuf);
        [StructLayout(LayoutKind.Sequential)]
        public struct _SERVER_INFO_100
        {
            internal int sv100_platform_id;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string sv100_name;
        }
        #endregion

        #region Public Methods
        public ArrayList getNetworkComputers()
        {
            ArrayList networkComputers = new ArrayList();
            const int MAX_PREFERRED_LENGTH = -1;
            int SV_TYPE_WORKSTATION = 1;
            int SV_TYPE_SERVER = 2;
            IntPtr buffer = IntPtr.Zero;
            IntPtr tmpBuffer = IntPtr.Zero;
            int entriesRead = 0;
            int totalEntries = 0;
            int resHandle = 0;
            int sizeofINFO = Marshal.SizeOf(typeof(_SERVER_INFO_100));
            try
            {

                int ret = NetServerEnum(null, 100, ref buffer, MAX_PREFERRED_LENGTH, out entriesRead, out totalEntries, SV_TYPE_WORKSTATION | SV_TYPE_SERVER, null, out resHandle);
                if (ret == 0)
                {
                    for (int i = 0; i < totalEntries; i++)
                    {
                        tmpBuffer = new IntPtr((int)buffer + (i * sizeofINFO));

                        _SERVER_INFO_100 svrInfo = (_SERVER_INFO_100)
                        Marshal.PtrToStructure(tmpBuffer, typeof(_SERVER_INFO_100));
                        networkComputers.Add(svrInfo.sv100_name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem with acessing network computers in NetworkBrowser " +
                "\r\n\r\n\r\n" + ex.Message,
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                NetApiBufferFree(buffer);
            }
            return networkComputers;
        }
        #endregion
    }
}
