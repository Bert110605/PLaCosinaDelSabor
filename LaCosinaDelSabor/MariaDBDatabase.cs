using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;
using LaCosinaDelSabor.Models;

namespace LaCosinaDelSabor.Services
{
    public class MariaDBDatabase
    {
<<<<<<< HEAD
        private readonly string _connectionString = "Server=localhost;Database=comida;User=root;Password=1234;";
=======
        private readonly string _connectionString = "Server=localhost;Database=comida;User=root;Password=12345678;";
>>>>>>> Los cambios finales para MSQL

        // Método para obtener un administrador basado en usuario y contraseña
        public async Task<Administrador> GetAdministradorAsync(string usuario, string contrasena)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var command = new MySqlCommand("SELECT * FROM administrador WHERE usuario = @Usuario AND contrasena = @Contrasena", connection);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrasena", contrasena);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Administrador
                            {
                                Usuario = reader.GetString("usuario"),
                                Contrasena = reader.GetString("contrasena")
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        // Método para obtener todos los empleados
        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            var empleados = new List<Empleado>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM empleado", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        empleados.Add(new Empleado
                        {
                            Id = reader.GetInt32("id_empleado"),
                            Nombre = reader.GetString("nombre"),
                            Apellido = reader.GetString("apellido"),
                            SalarioMXN = reader.GetInt32("salario_MXN"),  // Cambiado a GetInt32
                            FechaContratacion = reader.GetDateTime("fecha_contratacion"),
                            IdPuesto = reader.GetInt32("id_puesto")
                        });
                    }
                }
            }

            return empleados;
        }

        // Método para obtener un empleado por ID
        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM empleado WHERE id_empleado = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Empleado
                        {
                            Id = reader.GetInt32("id_empleado"),
                            Nombre = reader.GetString("nombre"),
                            Apellido = reader.GetString("apellido"),
                            SalarioMXN = reader.GetInt32("salario_MXN"),  // Cambiado a GetInt32
                            FechaContratacion = reader.GetDateTime("fecha_contratacion"),
                            IdPuesto = reader.GetInt32("id_puesto")
                        };
                    }
                }
            }

            return null;
        }

        // Método para guardar un empleado
        public async Task<int> SaveEmpleadoAsync(Empleado empleado)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("INSERT INTO empleado (id_empleado, nombre, apellido, salario_MXN, fecha_contratacion, id_puesto) VALUES (@Id, @Nombre, @Apellido, @SalarioMXN, @FechaContratacion, @IdPuesto)", connection);
                command.Parameters.AddWithValue("@Id", empleado.Id);
                command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                command.Parameters.AddWithValue("@SalarioMXN", empleado.SalarioMXN);  // Cambiado a int
                command.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion);
                command.Parameters.AddWithValue("@IdPuesto", empleado.IdPuesto);

                return await command.ExecuteNonQueryAsync();
            }
        }

        // Método para obtener todos los platillos
        public async Task<List<Plato>> GetPlatillosAsync()
        {
            var platillos = new List<Plato>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM plato", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        platillos.Add(new Plato
                        {
                            IdPlato = reader.GetInt32("id_plato"),
                            Nombre = reader.GetString("nombre"),
                            Precio = reader.GetDecimal("precio"),
                            ValorNutricional = reader.GetString("valor_nutricional"),
                            IdCategoria = reader.GetInt32("id_categoria")
                        });
                    }
                }
            }

            return platillos;
        }

        // Método para guardar un plato
        public async Task<int> SavePlatoAsync(Plato plato)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("INSERT INTO plato (id_plato, nombre, precio, valor_nutricional, id_categoria) VALUES (@IdPlato, @Nombre, @Precio, @ValorNutricional, @IdCategoria)", connection);
                command.Parameters.AddWithValue("@IdPlato", plato.IdPlato);
                command.Parameters.AddWithValue("@Nombre", plato.Nombre);
                command.Parameters.AddWithValue("@Precio", plato.Precio);
                command.Parameters.AddWithValue("@ValorNutricional", plato.ValorNutricional);
                command.Parameters.AddWithValue("@IdCategoria", plato.IdCategoria);

                return await command.ExecuteNonQueryAsync();
            }
        }
        // Método para obtener todos los proveedores
        public async Task<List<Proveedor>> GetProveedoresAsync()
        {
            var proveedores = new List<Proveedor>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM proveedor", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        try
                        {
                            var proveedor = new Proveedor
                            {
                                IdProveedor = reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                                Nombre = reader.IsDBNull(reader.GetOrdinal("nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("nombre")),
                                Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? string.Empty : reader.GetInt32(reader.GetOrdinal("telefono")).ToString(),
                                Direccion = reader.IsDBNull(reader.GetOrdinal("direccion")) ? string.Empty : reader.GetString(reader.GetOrdinal("direccion"))
                            };

                            proveedores.Add(proveedor);
                        }
                        catch (InvalidCastException ex)
                        {
                            // Manejo de la excepción
                            Console.WriteLine($"Error al leer los datos del proveedor: {ex.Message}");
                        }
                    }
                }
            }

            return proveedores;
        }

        // Método para obtener todos los ingredientes
        public async Task<List<Ingrediente>> GetIngredientesAsync()
        {
            var ingredientes = new List<Ingrediente>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM ingrediente", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ingredientes.Add(new Ingrediente
                        {
                            IdIngrediente = reader.GetInt32("id_ingrediente"),
                            Nombre = reader.GetString("nombre"),
                            Cantidad = reader.GetInt32("cantidad"),
                            Unidad = reader.GetString("unidad"),
                            Origen = reader.GetString("origen"),
                            Sostenibilidad = reader.GetBoolean("sostenibilidad"),
                            IdProveedor = reader.GetInt32("id_proveedor")
                        });
                    }
                }
            }

            return ingredientes;
        }
        // Método para guardar un ingrediente
        public async Task<int> SaveIngredienteAsync(Ingrediente ingrediente)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("INSERT INTO ingrediente (nombre, cantidad, unidad, origen, sostenibilidad, id_proveedor) VALUES (@Nombre, @Cantidad, @Unidad, @Origen, @Sostenibilidad, @IdProveedor)", connection);
                command.Parameters.AddWithValue("@Nombre", ingrediente.Nombre);
                command.Parameters.AddWithValue("@Cantidad", ingrediente.Cantidad);
                command.Parameters.AddWithValue("@Unidad", ingrediente.Unidad);
                command.Parameters.AddWithValue("@Origen", ingrediente.Origen);
                command.Parameters.AddWithValue("@Sostenibilidad", ingrediente.Sostenibilidad);
                command.Parameters.AddWithValue("@IdProveedor", ingrediente.IdProveedor);

                return await command.ExecuteNonQueryAsync();
            }
        }

        // Método para obtener todos los desperdicios
        public async Task<List<Desperdicio>> GetDesperdiciosAsync()
        {
            var desperdicios = new List<Desperdicio>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM desperdicio", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        desperdicios.Add(new Desperdicio
                        {
                            IdDesperdicio = reader.GetInt32(reader.GetOrdinal("id_desperdicio")),
                            IdPlato = reader.GetInt32(reader.GetOrdinal("id_plato")),
                            CantidadPlato = reader.GetDecimal(reader.GetOrdinal("cantidad_plato")),
                            IdIngrediente = reader.GetInt32(reader.GetOrdinal("id_ingrediente")),
                            CantidadIngrediente = reader.GetDecimal(reader.GetOrdinal("cantidad_ingrediente")),
                            Unidad = reader.GetString(reader.GetOrdinal("unidad")),
                            Motivo = reader.GetString(reader.GetOrdinal("motivo")),
                            Fecha = reader.GetDateTime(reader.GetOrdinal("fecha"))
                        });
                    }
                }
            }

            return desperdicios;
        }

        // Método para guardar un desperdicio
        public async Task<int> SaveDesperdicioAsync(Desperdicio desperdicio)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Generar manualmente un ID único
                var commandGetMaxId = new MySqlCommand("SELECT COALESCE(MAX(id_desperdicio), 0) + 1 FROM desperdicio", connection);
                int newId = Convert.ToInt32(await commandGetMaxId.ExecuteScalarAsync());

                var command = new MySqlCommand("INSERT INTO desperdicio (id_desperdicio, id_plato, cantidad_plato, id_ingrediente, cantidad_ingrediente, unidad, motivo, fecha) VALUES (@IdDesperdicio, @IdPlato, @CantidadPlato, @IdIngrediente, @CantidadIngrediente, @Unidad, @Motivo, @Fecha)", connection);
                command.Parameters.AddWithValue("@IdDesperdicio", newId);
                command.Parameters.AddWithValue("@IdPlato", desperdicio.IdPlato);
                command.Parameters.AddWithValue("@CantidadPlato", desperdicio.CantidadPlato);
                command.Parameters.AddWithValue("@IdIngrediente", desperdicio.IdIngrediente);
                command.Parameters.AddWithValue("@CantidadIngrediente", desperdicio.CantidadIngrediente);
                command.Parameters.AddWithValue("@Unidad", desperdicio.Unidad);
                command.Parameters.AddWithValue("@Motivo", desperdicio.Motivo);
                command.Parameters.AddWithValue("@Fecha", desperdicio.Fecha);

                return await command.ExecuteNonQueryAsync();

            }
        }

    }

}


   
