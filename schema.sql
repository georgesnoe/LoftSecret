-- =================================================================
-- Table for User Roles
-- Stores different types of users (e.g., client, proprietary, admin).
-- =================================================================
CREATE TABLE roles (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(32) NOT NULL UNIQUE
);

-- =================================================================
-- Table for Reservation Statuses
-- Stores possible states for a reservation (e.g., pending, confirmed).
-- =================================================================
CREATE TABLE status (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(32) NOT NULL UNIQUE
);

-- =================================================================
-- Table for Physical Locations
-- Stores address and geographic information.
-- =================================================================
CREATE TABLE localisations (
    id INT PRIMARY KEY AUTO_INCREMENT,
    description TEXT NOT NULL,
    adresse_google_maps TEXT
);

-- =================================================================
-- Table for Users
-- Stores user account information.
-- =================================================================
CREATE TABLE utilisateurs (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(64) NOT NULL,
    prenoms VARCHAR(64) NOT NULL,
    telephone VARCHAR(16) NOT NULL,
    email VARCHAR(64) NOT NULL UNIQUE,
    mot_de_passe VARCHAR(128) NOT NULL,
    date_inscription DATETIME NOT NULL,
    role_id INT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES roles(id)
);

-- =================================================================
-- Table for Rental Locations/Emplacements
-- The central table for properties that can be rented.
-- =================================================================
CREATE TABLE emplacement (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    description TEXT,
    superficie INT,
    capacite_max INT,
    prix INT NOT NULL,
    localisation_id INT NOT NULL,
    utilisateur_id INT NOT NULL,
    FOREIGN KEY (localisation_id) REFERENCES localisations(id),
    FOREIGN KEY (utilisateur_id) REFERENCES utilisateurs(id)
);

-- =================================================================
-- Table for Reservations
-- Connects users to the locations they book.
-- =================================================================
CREATE TABLE reservation (
    id INT PRIMARY KEY AUTO_INCREMENT,
    debut_reservation DATETIME NOT NULL,
    fin_reservation DATETIME NOT NULL,
    utilisateur_id INT NOT NULL,
    emplacement_id INT NOT NULL,
    status_id INT NOT NULL,
    FOREIGN KEY (utilisateur_id) REFERENCES utilisateurs(id),
    FOREIGN KEY (emplacement_id) REFERENCES emplacements(id),
    FOREIGN KEY (status_id) REFERENCES status(id)
);

-- =================================================================
-- Table for Media
-- Stores links to photos and videos for each location.
-- =================================================================
CREATE TABLE medias (
    id INT PRIMARY KEY AUTO_INCREMENT,
    lien VARCHAR(255) NOT NULL,
    emplacement_id INT NOT NULL,
    FOREIGN KEY (emplacement_id) REFERENCES emplacements(id)
);

-- =================================================================
-- Table for Testimonials/Reviews
-- Stores user reviews and ratings for locations.
-- =================================================================
CREATE TABLE temoignages (
    id INT PRIMARY KEY AUTO_INCREMENT,
    texte TEXT,
    vote INT,
    date_vote DATETIME NOT NULL,
    utilisateur_id INT NOT NULL,
    emplacement_id INT NOT NULL,
    FOREIGN KEY (utilisateur_id) REFERENCES utilisateurs(id),
    FOREIGN KEY (emplacement_id) REFERENCES emplacements(id)
);