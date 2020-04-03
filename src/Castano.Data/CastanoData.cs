namespace Castano.Data
{
    using Castano.Data.Pedido;
    using System.Collections.Generic;

    public class CastanoData : ICastanoData
    {
        ICastanoRepository<Equipo> _Equipos;
        public ICastanoRepository<Equipo> EquiposRepository
        {
            get
            {
                if (_Equipos == null)
                {
                    var equipo = new HashSet<Equipo>
                    {
                        //Multimedia
                        new Equipo
                        {
                            SoloConAnticipacion = false,
                            Tipo = "Multimedia",
                            Nombre = "PROYECCION MULTIMEDIA 3000",
                            Precio = 2500,
                            Descripcion = "Resolución nativa: XGA(1024x768) / Acepta todas las resoluciones hasta 4K(3840 x 2160) / Conectividad VGA o HDMI / Luminosidad: 3000 lúmenes."
                        },
                        new Equipo
                        {
                            SoloConAnticipacion = false,
                            Tipo = "Multimedia",
                            Nombre = "PROYECCION MULTIMEDIA 3500",
                            Precio = 3400,
                            Descripcion = "Resolución nativa: WXGA(1280x800) / Acepta todas las resoluciones hasta 4K(3840x2160) / Conectividad VGA o HDMI / Luminosidad: 3500 lúmenes."
                        },
                        new Equipo
                        {
                            SoloConAnticipacion = true,
                            Tipo = "Multimedia",
                            Nombre = "PROYECCION MULTIMEDIA 4500 FULL HD",
                            Precio = 6400,
                            Descripcion = "Resolución nativa: FULL HD(1080p: 1920x1080) / Acepta todas las resoluciones hasta 4K(3840x2160) / Conectividad VGA o HDMI / Luminosidad: 4500 lúmenes / Contraste: 20.000:1"
                        },
                        new Equipo
                        {
                            SoloConAnticipacion = false,
                            Tipo = "Multimedia",
                            Nombre = "INSTALACION PROYECTOR EN TECHO",
                            Precio = 750,
                            Descripcion = "Instalación con soporte de techo / cableado necesario.",
                            Aclaracion = "(Sólo en caso de ser posible por caracterísiticas de cielorraso)"
                        },
                        new Equipo
                        {
                            SoloConAnticipacion = true,
                            Tipo = "Multimedia",
                            Nombre = "ESCALADOR / SELECTOR DE SEÑALES / MATRIZ / SWITCHER / SPLITTER",
                            Precio = 2000,
                            Descripcion = "Dispositivos para mezclar y/o multipicar señales de diferentes procedencias enviándolas a uno o más equipos de proyección. Entrega una conmutación libre de saltos entre fuentes.",
                            IndicadoPara = "presentaciones que requieran mezclar señales provenientes de diferentes fuentes de datos (pc, notebook, netbook, etc.) y/o video (reproductor dvd, blu-ray, cámaras, etc.) conmutándolas de manera prolija sin necesidad de efectuar cambios de entradas desde el proyector."

                        },
                        new Equipo
                        {
                            SoloConAnticipacion = false,
                            Tipo = "Multimedia",
                            Nombre = "NOTEBOOK BASE",
                            Precio = 1050,
                            Descripcion = "Procesador de doble núcleo 1000mhz / Memoria RAM 2GB / Unidad de disco duro 500GB / Lectoras CD-DVD / Puertos USB / Mouse / Sistema Operativo Microsoft® Windows® 10 / Software: Microsoft® Office, Reproductores Multimedia, etc."
                        },
                        new Equipo
                        {
                            SoloConAnticipacion = false,
                            Tipo = "Multimedia",
                            Nombre = "NOTEBOOK i7",
                            Precio = 1350,
                            Descripcion = "Procesador Intel Core i7 / Memoria RAM 8GB / Unidad de disco duro 1TB / Lectoras CD-DVD / Puertos USB 3.0 / Mouse / Sistema Operativo Microsoft® Windows® 10 / Software: Microsoft® Office, Reproductores Multimedia, etc.",
                            IndicadoPara = "Para todo tipo de video conferencias web."
                        },
                        new Equipo
                        {
                            SoloConAnticipacion = false,
                            Tipo = "Multimedia",
                            Nombre = "CONTROL REMOTO INALAMBRICO PARA PRESENTACIONES (PASA SLIDES)",
                            Precio = 230,
                            Descripcion = "Control inalámbrico por radio frecuencia para presentaciones multimedia con puntero láser incluído.",
                            IndicadoPara = "Disertantes muy dinámicos que no puedan estar \"prisioneros\" de la posición de la notebook y estén habituados al dispositivo.",
                            Aclaracion = "Este precio vale en los casos en que el pasa slides esté acompañado de PROYECCION MULTIMEDIA. Caso contrario tiene un recargo del 100%"
                        },
                        new Equipo
                        {
                            SoloConAnticipacion = false,
                            Tipo = "Multimedia",
                            Nombre = "CABLEADO VGA O HDMI",
                            Precio = 280,
                            Descripcion = "Válido en caso de requerir solamente el cableado (el conexionado es sin cargo cuando se contrata PROYECCION MULTIMEDIA)",
                            Aclaracion = "Sujeto a disponibilidad"
                        },
                        //Sonido
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "BAFLES PARA NOTEBOOK",
                            Precio = 330,
                            Descripcion = "(No admite agregado de micrófonos). Par de bafles potenciados de 450W (PMPO).",
                            Aclaracion = "Este precio vale en los casos en que los bafles potenciados esten acompañados de PROYECCIÓN MULTIMEDIA. Caso contrario tiene un recargo del 50%.",
                            IndicadoPara = "Amplificar el sonido de notebooks u otros dispositivos en reuniones en las que el número de asistentes no justifica el agregado de un sistema de sonido (ej.: hasta 40 pers.)",

                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "SONIDO BASE",
                            Precio = 3900,
                            Descripcion = "(cuando vaya acompañado de PROYECCIÓN y/o NOTEBOOK) Potencia amplificadora / Consola mezcladora 8ch / 1 Micrófono volante(demano) inalámbrico / 1 micrófono sola pero inalámbrico / 2 cajas acústicas / música funcional (NO ES SERVICIO DE DISC-JOCKEY) / 1 direct box (conexión para audio de notebook) / OPERADOR.",
                            Aclaracion = "Micrófonos: el sistema incluye el set de inalámbricos (1 de mano + 1 corbatero), cualquier otro micrófono será cobrado como adicional. Admite el agregado de hasta 2 micrófonos (inalámbricos o de cable), los que serán cobrados como adicionales."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "SONIDO BASE SIN PROYECCIÓN",
                            Precio = 5100,
                            Descripcion = "(cuando no vaya acompañado de PROYECCIÓN y/o NOTEBOOK) Par de bafles potenciados de 450W (PMPO).",
                            IndicadoPara = "Amplificar el sonido de notebooks u otros dispositivos en reuniones en las que el número de asistentes no justifica el agregado de un sistema de sonido (ej.: hasta 40 pers.)",
                            Aclaracion = "Este precio vale en los casos en que los bafles potenciados esten acompañados de PROYECCIÓN MULTIMEDIA. Caso contrario tiene un recargo del 50%."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "SONIDO ECONÓMICO",
                            SoloConAnticipacion = true,
                            Precio = 2300,
                            Descripcion = "Este sonido cuenta solo con 1 micrófono de cable y amplificación de audio de notebook / SIN PRESENCIA DE OPERADOR",
                            IndicadoPara = "Eventos en los que sólo sea necesario un refuerzo de sonido mínimo/la calidad de sonido es inferior a la del SONIDO BASE",
                            Aclaracion = "No admite agregado de micrófonos adicionales de ningún tipo."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "SONIDO ALTO IMPACTO",
                            SoloConAnticipacion = true,
                            Precio = 8000,
                            Descripcion = "Consola mezcladora 16ch / 1 micrófono volante (demano) inalámbrico / 1 micrófono head-set inalámbrico / 2 cajas acústicas potenciadas 300W / música funcional (NO ES SERVICIO DE DISC-JOCKEY) / 1 direct box (conexión para audio de notebook) / OPERADOR",
                            IndicadoPara = "Eventos en los que sólo sea necesario un refuerzo de sonido mínimo/la calidad de sonido es inferior a la del SONIDO BASE",
                            Aclaracion = "No admite agregado de micrófonos adicionales de ningún tipo."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "GRABACION DE SONIDO",
                            Precio = 1050,
                            Descripcion = "Grabación de audio del evento completo en formato mp3.",
                            Aclaracion = "El archivo se entrega al finalizar el evento en un cd o dvd (dependiendo de su extensión) o copiándoselo al cliente en algún dispositivo propio."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "MIC CABLE ADICIONAL",
                            Precio = 220,
                            Descripcion = "Micrófonos de cable SHURE SM58."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "MIC INALÁMBRICO ADICIONAL",
                            Precio = 360,
                            Descripcion = "Micrófono inalámbrico UHF / aclarar siempre si se trata de micrófono tipo volante (demano / hanheld), solapero (corbatero / lavalier) o head-set (vincha)."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "CAJA ACUSTICA ADICIONAL",
                            Precio = 510,
                            Descripcion = "Agregado de caja acúsica (bafle) adicional al par incluido en el sistema de sonido / para refuerzo de sala o monitoreo."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "SISTEMA DE AUDIO 2,1",
                            Precio = 620,
                            Descripcion = "Sintonizador de radio FM / conectividad bluetooth / puerto USB / lector de tarjeta SD / potencia 1200 W PMPO.",
                            IndicadoPara = "Eventos en los que no se contrate SONIDO BASE pero requieran de un dispositivo para amplificar archivos de audios / musica ambiente / etc."
                        },
                        new Equipo
                        {
                            Tipo = "Sonido",
                            Nombre = "SPEAK PHONE PARA VIDEO O AUDIO CONFERENCIAS",
                            Precio = 800,
                            Descripcion = "Alta voz con micrófono omnidireccional incorporado capaz de emitir y reproducir audio en una video conferencia para un grupo de asistentes limitados (mesa directorio) / conectividad usb."
                        },
                        //Monitores TV
                        new Equipo
                        {
                            Tipo = "Monitores TV",
                            Nombre = "TV LCD 40\"",
                            Precio = 2500,
                            Descripcion = "TV LCD 40\" FULL HD (1080p.). Incluye: Soporte de piso (alt. min.: 1,90mts. / alt. máx.: 2,35mts.) o mesa."
                        },
                        new Equipo
                        {
                            Tipo = "Monitores TV",
                            Nombre = "TV LCD 50/55\"",
                            Precio = 3300,
                            Descripcion = "TV LCD 50/55\" FULL HD (1080p.) o UHD - 4K (2160p.). Incluye: Soporte de piso (alt. min.: 1,90mts. / alt. máx.: 2,35mts.) o mesa."
                        },
                        //Pantallas y Rotafolios
                        new Equipo
                        {
                            Tipo = "Pantallas y Rotafolios",
                            Nombre = "160",
                            Precio = 380,
                            Descripcion = "Pantalla de 1,60 x 1,60 mts / enrollable con trípode / 80\" (4:3) / 72\" (16:9)."
                        },
                        new Equipo
                        {
                            Tipo = "Pantallas y Rotafolios",
                            Nombre = "200",
                            Precio = 460,
                            Descripcion = "Pantalla de 2,00 x 1,52 mts / enrollable con trípode / 100\" (4:3) / 90\" (16:9)."
                        },
                        new Equipo
                        {
                            Tipo = "Pantallas y Rotafolios",
                            Nombre = "250",
                            Precio = 600,
                            Descripcion = "Pantalla de 2,50 x 1,90 mts / enrollable con trípode / 125\" (4:3) / 110\" (16:9)."
                        },
                        new Equipo
                        {
                            Tipo = "Pantallas y Rotafolios",
                            Nombre = "260 4:3 ESTRUCTURAL",
                            Precio = 1250,
                            Descripcion = "Pantalla de 2,60 x 2,00 mts / 130\" (4:3) / 120\" (16:9)."
                        },
                        new Equipo
                        {
                            Tipo = "Pantallas y Rotafolios",
                            Nombre = "ROTAFOLIOS",
                            Precio = 380,
                            Descripcion = "Rotafolios de 1,00 x 0,70 mts.",
                            Aclaracion = "No Incluye hojas ni fibrones."
                        },
                        //Iluminacion
                        new Equipo
                        {
                            Tipo = "Iluminacion",
                            Nombre = "PAR 300",
                            Precio = 320,
                            Descripcion = "Artefacto para lámpara par 56 (300W) montado en trípode de hasta 4 artefactos o apoyados en piso / luz blanca o color fijo mediante gelatina."
                        },
                        new Equipo
                        {
                            Tipo = "Iluminacion",
                            Nombre = "PAR LED",
                            Precio = 480,
                            Descripcion = "Artefacto led RGBW (rojo / verde / azul / blanco) 51 pcs. por color montado en trípode de hasta 4 artefactos o apoyados en piso / luz blanca o colores variables / programas con variación y fundido de colores.",
                            Aclaracion = "Apto para usar con consola de iluminación dmx (no incluida en el precio)"
                        },
                        new Equipo
                        {
                            Tipo = "Iluminacion",
                            Nombre = "CONSOLA DMX",
                            SoloConAnticipacion = true,
                            Precio = 950,
                            Descripcion = "Dispositivo que permite variación, mezcla de colores y atenuación de intensidad de los artefactos led."
                        },
                        //Otros
                        new Equipo
                        {
                            Tipo = "Otros",
                            Nombre = "TARIMA - ESCENARIO",
                            SoloConAnticipacion = true,
                            Precio = 6000,
                            Descripcion = "Medidas: 3,00 x 2,00 mts. Estructura de aluminio reforzado (módulos de 2.00 x 1.00 mts.) / Altura 0,45; 0.60 o 1.00mts / Piso de terciado fenólico pintado gris oscuro (no alfombrada) / perímetro vestido con tela tableada color negro."
                        },
                        new Equipo
                        {
                            Tipo = "Otros",
                            Nombre = "ZAPATILLAS 220V - 4 a 6 bocas",
                            SoloConAnticipacion = true,
                            Precio = 100,
                            Descripcion = "Zapatillas adicionales a las necesarias para alimentar a los servicios contratados."
                        },
                        //Operador
                        new Equipo
                        {
                            Tipo = "Operador",
                            Nombre = "OPERADOR JORNADA COMPLETA (DIA HABIL)",
                            Precio = 2080,
                            Descripcion = "De 4 a 9 hs / para servicios que no lo incluyan."
                        },
                        new Equipo
                        {
                            Tipo = "Operador",
                            Nombre = "OPERADOR MEDIA JORNADA (DIA HABIL)",
                            Precio = 1560,
                            Descripcion = "Hasta 4 hs / para servicios que no lo incluyan."
                        }
                    };

                    _Equipos = new CastanoMemoryRepository<Equipo>(equipo);
                }

                return _Equipos;
            }
        }
    }
}
