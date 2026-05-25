script para crear la base de datos desde cero



CREATE DATABASE IF NOT EXISTS login_system DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE login_system;

-- Tabla de usuarios
CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    contraseña VARCHAR(50) NOT NULL,
    rol ENUM('jugador','administrador') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Tabla de módulos educativos
CREATE TABLE modulos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL UNIQUE,
    descripcion TEXT
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Tabla de preguntas (con columna de idioma)
CREATE TABLE preguntas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    modulo_id INT NOT NULL,
    enunciado TEXT NOT NULL,
    idioma VARCHAR(10) NOT NULL DEFAULT 'español',
    FOREIGN KEY (modulo_id) REFERENCES modulos(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Tabla de opciones de respuesta
CREATE TABLE opciones (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pregunta_id INT NOT NULL,
    texto VARCHAR(255) NOT NULL,
    es_correcta BOOLEAN NOT NULL DEFAULT FALSE,
    FOREIGN KEY (pregunta_id) REFERENCES preguntas(id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Insertar los cuatro módulos obligatorios
INSERT INTO modulos (nombre, descripcion) VALUES 
('Arquitectura del Computador', 'Estudio de la organización y funcionamiento interno de un computador.'),
('Antropología', 'Exploración de las culturas humanas, evolución y sociedad.'),
('Cálculo', 'Estudio de límites, derivadas, integrales y aplicaciones.'),
('Deportes', 'Reglamentos, técnicas y estrategias de disciplinas deportivas.');

-- (Opcional) Insertar usuarios de prueba
INSERT INTO usuarios (nombre, contraseña, rol) VALUES 
('admin', 'admin', 'administrador'),
('jugador', 'jugador', 'jugador');
