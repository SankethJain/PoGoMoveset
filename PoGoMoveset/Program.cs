using Newtonsoft.Json;
using PoGoMoveset.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PoGoMoveset
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var gameMasterJson = File.ReadAllText(@"E:\Personal\Projects\Github\pvpoke\src\data\gamemaster.json");
                var model = JsonConvert.DeserializeObject<GameMaster>(gameMasterJson);

                var fastMoves = model.Moves.Where(x => x.EnergyGain > 0 || x.MoveId == "TRANSFORM").ToArray();
                var chargedMoves = model.Moves.Where(x => x.EnergyGain == 0 && x.MoveId != "TRANSFORM").ToArray();

                var bestEgpt = model.Moves.OrderByDescending(x => x.EGPT).ToArray();
                var bestEGD = model.Moves.OrderByDescending(x => x.EGDamage).ToArray();

                var fastestChargingChargeMove = chargedMoves.OrderBy(x => x.Energy).ToArray();
                var mostDamagingFCC = chargedMoves.OrderByDescending(x => x.DPE).ToArray();

                var comboMoves = new List<ComboMoves>();
                foreach(var fast in fastMoves)
                {
                    foreach(var charged in chargedMoves)
                    {
                        comboMoves.Add(new ComboMoves { ChargedMove = charged, FastMove = fast });
                    }
                }
                var mostDamagingMoveComboPerTurn = comboMoves.OrderByDescending(x => x.CombinedDPT).ToArray();
                var mostDeadly = comboMoves.OrderByDescending(x => x.MostEfficient).ToArray();

                foreach(var move in comboMoves)
                {
                    var pokemon = model.Pokemon
                        .Where(x => x.FastMoves.Contains(move.FastMove.MoveId) && x.ChargedMoves.Contains(move.ChargedMove.MoveId))
                        .ToArray();
                    move.Pokemon = pokemon;
                }

                var output = mostDeadly.Select(x => new
                {
                    ChargedMove = x.ChargedMove.Name,
                    FastMove = x.FastMove.Name,
                    Efficiency = x.MostEfficient,
                    Pokemon = string.Join(",", x.Pokemon.Select(x=>x.SpeciesName))
                });
                var dt = ToDataTable(output);
                var csv = ToCsv(dt);

                File.WriteAllText(@"C:\Users\sanke\Desktop\PoGoEfficiency.csv", csv, Encoding.UTF8);

                //var documentBytes = Encoding.UTF8.GetBytes(csv);
                //string mimeType = "text/csv";
                //var fileContent = new FileContentResult(documentBytes, mimeType)
                //{
                //    FileDownloadName = fileName
                //};
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ToCsv(DataTable dt)
        {
            var content = new StringBuilder();

            // Headers
            foreach (DataColumn col in dt.Columns)
            {
                content.Append("\"" + col.ColumnName + "\",");
            }
            content.AppendLine();

            foreach (DataRow row in dt.Rows)
            {
                var csvRow = new StringBuilder();
                foreach (DataColumn col in dt.Columns)
                {
                    csvRow.Append("\"" + row[col.ColumnName] + "\",");
                }

                content.AppendLine(csvRow.ToString());
            }

            return content.ToString();
        }

        public static DataTable ToDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties()
                //.Where(x => x.PropertyType == typeof(string))
                .ToArray();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                var attr = info.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                var columnName = attr?.Name ?? info.Name;
                dataTable.Columns.Add(new DataColumn(columnName, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
