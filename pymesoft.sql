-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-07-2018 a las 03:44:04
-- Versión del servidor: 10.1.32-MariaDB
-- Versión de PHP: 5.6.36

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `pymesoft`
--
CREATE DATABASE IF NOT EXISTS `pymesoft` DEFAULT CHARACTER SET utf8 COLLATE utf8_spanish_ci;
USE `pymesoft`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `id` int(11) NOT NULL,
  `persona_id` int(11) NOT NULL,
  `vendedor_id` int(11) NOT NULL DEFAULT '1',
  `termino_pago_id` int(11) NOT NULL DEFAULT '1',
  `cliente_balance` decimal(15,2) NOT NULL DEFAULT '0.00',
  `cliente_limite_credito` decimal(15,2) NOT NULL DEFAULT '0.00',
  `cliente_ultima_compra` datetime NOT NULL,
  `cliente_estado_registro` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`id`, `persona_id`, `vendedor_id`, `termino_pago_id`, `cliente_balance`, `cliente_limite_credito`, `cliente_ultima_compra`, `cliente_estado_registro`) VALUES
(1, 2, 1, 1, '5000.00', '0.00', '0000-00-00 00:00:00', 0),
(2, 4, 2, 1, '2500.00', '0.00', '0000-00-00 00:00:00', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `configuracion_empresa`
--

CREATE TABLE `configuracion_empresa` (
  `id` int(11) NOT NULL,
  `configuracion_empresa_nombre` varchar(200) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `configuracion_empresa_eslogan` text COLLATE utf8_spanish_ci NOT NULL,
  `configuracion_empresa_rnc` varchar(25) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `configuracion_empresa_direccion` text COLLATE utf8_spanish_ci NOT NULL,
  `configuracion_empresa_telefono` varchar(25) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `configuracion_empresa_correo_electronico` varchar(200) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `configuracion_empresa_sitio_web` varchar(200) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `configuracion_empresa_logo` varchar(255) COLLATE utf8_spanish_ci NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `configuracion_empresa`
--

INSERT INTO `configuracion_empresa` (`id`, `configuracion_empresa_nombre`, `configuracion_empresa_eslogan`, `configuracion_empresa_rnc`, `configuracion_empresa_direccion`, `configuracion_empresa_telefono`, `configuracion_empresa_correo_electronico`, `configuracion_empresa_sitio_web`, `configuracion_empresa_logo`) VALUES
(1, 'Luminous Beauty Salon', '', '130674779', 'Av. Juan Pablo Duarte #100 Plaza Navona', '809-587-6606', '', '', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `historial_accesos_usuarios`
--

CREATE TABLE `historial_accesos_usuarios` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `historial_acceso_fecha_entrada` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `historial_acceso_fecha_salida` datetime NOT NULL,
  `historial_acceso_usuario_conectado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personas`
--

CREATE TABLE `personas` (
  `id` int(11) NOT NULL,
  `persona_nombre` varchar(200) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `persona_identificacion` varchar(25) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `persona_correo_electronico` varchar(200) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `persona_direccion` text COLLATE utf8_spanish_ci NOT NULL,
  `persona_telefono_principal` varchar(25) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `persona_telefono_secundario` varchar(25) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `persona_fax` varchar(25) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `persona_celular` varchar(25) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `persona_observaciones` text COLLATE utf8_spanish_ci NOT NULL,
  `persona_pagina_web` varchar(200) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `persona_fecha_registro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `persona_tipo_id` int(11) NOT NULL,
  `persona_imagen` varchar(255) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `personas`
--

INSERT INTO `personas` (`id`, `persona_nombre`, `persona_identificacion`, `persona_correo_electronico`, `persona_direccion`, `persona_telefono_principal`, `persona_telefono_secundario`, `persona_fax`, `persona_celular`, `persona_observaciones`, `persona_pagina_web`, `persona_fecha_registro`, `persona_tipo_id`, `persona_imagen`) VALUES
(1, 'Vendedor General', '', '', '', '', '', '', '', '', '\' \'', '2018-06-19 19:36:52', 3, ''),
(2, 'Joel Tavarez', '03105352953', 'joeltavarezestevez@gmail.com', 'Santiago', '8094890312', '8094890039', '', '8499185757', '', '', '2018-06-26 14:37:23', 1, ''),
(3, 'Julio Peralta', '12345678', '', 'Santiago', '123235463', '12313123', '', '', '', '', '2018-06-26 14:38:41', 3, ''),
(4, 'Liam Tavarez', '40212314', '', 'Santiago', '', '', '', '', '', '', '2018-06-26 14:39:23', 1, '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personas_tipos`
--

CREATE TABLE `personas_tipos` (
  `id` int(11) NOT NULL,
  `persona_tipo_nombre` varchar(100) COLLATE utf8_spanish_ci NOT NULL DEFAULT ''' '''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `personas_tipos`
--

INSERT INTO `personas_tipos` (`id`, `persona_tipo_nombre`) VALUES
(1, 'Cliente'),
(2, 'Proveedor'),
(3, 'Vendedor');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE `proveedores` (
  `id` int(11) NOT NULL,
  `persona_id` int(11) NOT NULL,
  `termino_pago_id` int(11) NOT NULL DEFAULT '1',
  `proveedor_balance` decimal(15,2) NOT NULL DEFAULT '0.00',
  `proveedor_ultima_compra` datetime NOT NULL,
  `proveedor_estado_registro` tinyint(1) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `terminos_pago`
--

CREATE TABLE `terminos_pago` (
  `id` int(11) NOT NULL,
  `termino_pago_nombre` varchar(200) COLLATE utf8_spanish_ci NOT NULL DEFAULT ''' ''',
  `termino_pago_dias` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `terminos_pago`
--

INSERT INTO `terminos_pago` (`id`, `termino_pago_nombre`, `termino_pago_dias`) VALUES
(1, 'Al Contado', 0),
(2, '7 dias', 7),
(3, '15 dias', 15),
(4, '30 dias', 30),
(5, '60 dias', 60);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `usuario_nombre_completo` varchar(100) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `usuario_nombre` varchar(100) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `usuario_contrasena` varchar(200) COLLATE utf8_spanish_ci NOT NULL DEFAULT '',
  `usuario_tipo_id` int(11) NOT NULL,
  `usuario_fecha_registro` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `usuario_estado_registro` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id`, `usuario_nombre_completo`, `usuario_nombre`, `usuario_contrasena`, `usuario_tipo_id`, `usuario_fecha_registro`, `usuario_estado_registro`) VALUES
(1, 'Joel Tavarez', 'jtavarez', 'b93810ff1d6651b6d734f13dab99b3b0', 1, '2018-06-24 03:36:30', 1),
(2, 'Rodolfo Vargas', 'rvargas', '123456', 2, '2018-06-24 21:42:54', 1),
(3, 'Junior Vinas', 'jvinas', '123456', 1, '2018-06-24 21:43:26', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios_tipos`
--

CREATE TABLE `usuarios_tipos` (
  `id` int(11) NOT NULL,
  `usuario_tipo_nombre` varchar(100) COLLATE utf8_spanish_ci NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `usuarios_tipos`
--

INSERT INTO `usuarios_tipos` (`id`, `usuario_tipo_nombre`) VALUES
(1, 'Administrador'),
(2, 'Limitado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `vendedores`
--

CREATE TABLE `vendedores` (
  `id` int(11) NOT NULL,
  `persona_id` int(11) NOT NULL,
  `vendedor_comision` tinyint(1) NOT NULL DEFAULT '1',
  `vendedor_ultima_venta` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `vendedores`
--

INSERT INTO `vendedores` (`id`, `persona_id`, `vendedor_comision`, `vendedor_ultima_venta`) VALUES
(1, 1, 0, '0000-00-00 00:00:00'),
(2, 3, 1, '0000-00-00 00:00:00');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `persona_id` (`persona_id`),
  ADD KEY `vendedor_id` (`vendedor_id`),
  ADD KEY `termino_pago_id` (`termino_pago_id`);

--
-- Indices de la tabla `configuracion_empresa`
--
ALTER TABLE `configuracion_empresa`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `historial_accesos_usuarios`
--
ALTER TABLE `historial_accesos_usuarios`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `personas`
--
ALTER TABLE `personas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `persona_tipo_id` (`persona_tipo_id`);

--
-- Indices de la tabla `personas_tipos`
--
ALTER TABLE `personas_tipos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD PRIMARY KEY (`id`),
  ADD KEY `persona_id` (`persona_id`),
  ADD KEY `termino_pago_id` (`termino_pago_id`);

--
-- Indices de la tabla `terminos_pago`
--
ALTER TABLE `terminos_pago`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_tipo_id` (`usuario_tipo_id`);

--
-- Indices de la tabla `usuarios_tipos`
--
ALTER TABLE `usuarios_tipos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `vendedores`
--
ALTER TABLE `vendedores`
  ADD PRIMARY KEY (`id`),
  ADD KEY `persona_id` (`persona_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `clientes`
--
ALTER TABLE `clientes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `configuracion_empresa`
--
ALTER TABLE `configuracion_empresa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `historial_accesos_usuarios`
--
ALTER TABLE `historial_accesos_usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `personas`
--
ALTER TABLE `personas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `personas_tipos`
--
ALTER TABLE `personas_tipos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `terminos_pago`
--
ALTER TABLE `terminos_pago`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `usuarios_tipos`
--
ALTER TABLE `usuarios_tipos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `vendedores`
--
ALTER TABLE `vendedores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD CONSTRAINT `clientes_ibfk_1` FOREIGN KEY (`termino_pago_id`) REFERENCES `terminos_pago` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `clientes_ibfk_2` FOREIGN KEY (`vendedor_id`) REFERENCES `vendedores` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `clientes_ibfk_3` FOREIGN KEY (`persona_id`) REFERENCES `personas` (`id`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `historial_accesos_usuarios`
--
ALTER TABLE `historial_accesos_usuarios`
  ADD CONSTRAINT `historial_accesos_usuarios_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `personas`
--
ALTER TABLE `personas`
  ADD CONSTRAINT `personas_ibfk_1` FOREIGN KEY (`persona_tipo_id`) REFERENCES `personas_tipos` (`id`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD CONSTRAINT `proveedores_ibfk_1` FOREIGN KEY (`termino_pago_id`) REFERENCES `terminos_pago` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `proveedores_ibfk_2` FOREIGN KEY (`persona_id`) REFERENCES `personas` (`id`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`usuario_tipo_id`) REFERENCES `usuarios_tipos` (`id`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `vendedores`
--
ALTER TABLE `vendedores`
  ADD CONSTRAINT `vendedores_ibfk_1` FOREIGN KEY (`persona_id`) REFERENCES `personas` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
