using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackupsController : ControllerBase
    {
        public readonly SomosdcContext _context;
        public BackupsController(SomosdcContext context)
        {
            _context = context;
        }


        //[HttpGet]
        //public async Task<IActionResult> BackupDatabase()
        //{
        //    try
        //    {
        //        // Obtener la ruta de la carpeta donde se almacenará el respaldo
        //        string backupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
        //        if (!Directory.Exists(backupFolderPath))
        //        {
        //            Directory.CreateDirectory(backupFolderPath);
        //        }

        //        // Nombre del archivo de respaldo
        //        string mysqldumpPath = "C:\\Program Files\\MySQL\\MySQL Server 8.2\\bin\\mysqldump";
        //        string backupFileName = $"Backup_{DateTime.Now.ToString("yyyyMMddHHmmss")}.sql";
        //        string backupFilePath = Path.Combine(backupFolderPath, backupFileName);

        //        // Ejecutar el comando mysqldump para realizar el respaldo
        //        using (Process process = new Process())
        //        {
        //            process.StartInfo.FileName = mysqldumpPath;
        //            process.StartInfo.Arguments = $"-uroot -p1234 -hlocalhost somoscd > \"{backupFilePath}\"";
        //            process.StartInfo.RedirectStandardOutput = false;
        //            process.StartInfo.RedirectStandardInput = false;
        //            process.StartInfo.RedirectStandardError = true;
        //            process.StartInfo.UseShellExecute = false;
        //            process.StartInfo.CreateNoWindow = true;

        //            process.Start();
        //            process.WaitForExit();
        //        }

        //        return Ok(new { BackupFilePath = backupFilePath });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error al realizar el respaldo de la base de datos: {ex.Message}");
        //    }
        //}


        [HttpGet("2")]
        public IActionResult BackupDatabase1()
        {
            try
            {
                DateTime fechaActual = DateTime.Today;
                DateTime horaActual = DateTime.Now;

                // Formatear la fecha y la hora actual
                string fechaFormateada = fechaActual.ToString("yyyy-MM-dd");
                string horaFormateada = horaActual.ToString("HH-mm-ss");

                // Crear el nombre del archivo con la fecha y hora formateadas
                string nombreArchivo = $"respaldo_{fechaFormateada} {horaFormateada}.sql";
                string ruta = @$"C:\Users\Alex Morales\Desktop\Proyectos\Evaluacion\BackEnd\BackEnd\Backups\{nombreArchivo}";
                string ruta1 = @$"C:\Users\Alex Morales\Desktop\Proyectos\Evaluacion\BackEnd\BackEnd\Backups\{nombreArchivo}";
                string conexion = "Server=localhost; Database=somosdc; User=root; Password=1234;";
                using (MySqlConnection conexion1 = new MySqlConnection(conexion))
                {
                    using (MySqlCommand commando = new MySqlCommand())
                    {
                        using (MySqlBackup respaldo = new MySqlBackup(commando))
                        {
                            commando.Connection = conexion1;
                            commando.Connection.Open();
                            //respaldo.ExportToFile("C:\respaldo");
                             respaldo.ExportToFile(ruta);
                            conexion1.Close();
                            return Ok(new
                            {
                                ok=true,
                                mensaje="Backup Realizado correctamente !!",
                                ruta=ruta
                            });

                        }

                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

                [HttpGet]
        public IActionResult BackupDatabase()
        {
            try
            {
                string backupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                if (!Directory.Exists(backupFolderPath))
                {
                    Directory.CreateDirectory(backupFolderPath);
                }

                string mysqldumpPath = "C:\\Program Files\\MySQL\\MySQL Server 8.2\\bin\\mysqldump.exe";
                //string mysqldumpPath = "\"C:\\Program Files\\MySQL\\MySQL Server 8.2\\bin\\mysqldump\"";

                string backupFileName = $"Backup_{DateTime.Now.ToString("yyyyMMddHHmmss")}.sql";
                string backupFilePath = Path.Combine(backupFolderPath, backupFileName);

                using (Process process = new Process())
                {
                    process.StartInfo.FileName = mysqldumpPath;

                    process.StartInfo.Arguments = $"-uroot -p1234 -hlocalhost:3306 somoscd > \"{backupFilePath}\"";
                    process.StartInfo.RedirectStandardOutput = false;
                    process.StartInfo.RedirectStandardInput = false;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                    process.Start();
                    process.WaitForExit();
                }

                return Ok(new { BackupFileName = backupFileName });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al realizar el respaldo de la base de datos: {ex.Message}");
            }
        }



    }
}
