# Bankautomat Simulation (C#)

Eine Konsolenanwendung zur Simulation grundlegender Bankgeschäfte. Das Projekt konzentriert sich auf die Logik der Kontoführung und die Interaktion mit dem Benutzer über ein strukturiertes Menü.

Wichtiger Hinweis: Beim ersten Start erstellt das Programm automatisch einen Ordner namens BankProfilDaten auf Ihrem Desktop.

Warum? Dies dient der einfachen Nachverfolgbarkeit für Tester. In diesem Ordner wird die Datei artikel.json (bzw. kontodaten.json) abgelegt. So können Sie die Serialisierung der Daten direkt einsehen und validieren, ohne in den Programmverzeichnissen suchen zu müssen.


##  Umgesetzte Features & Konzepte
- **Kontostandsverwaltung:** Dynamische Verwaltung eines Guthabens während der Programmlaufzeit.
- **Transaktionslogik:** Implementierung von Ein- und Auszahlungsfunktionen inklusive Validierung des verfügbaren Guthabens (Vermeidung von Überziehungen).
- **Zustandsbasiertes Menü-System:** Aufbau einer interaktiven Menüstruktur mit `switch-case` und Schleifen zur Steuerung der Benutzerführung.
- **Eingabesicherung:** Verwendung von `double.TryParse` (oder `decimal.TryParse`), um fehlerhafte Betragseingaben abzufangen.

##  Was ich bei diesem Projekt gelernt habe
- **Logische Abläufe:** Die Modellierung von Finanztransaktionen und das Sicherstellen, dass nur gültige Beträge verarbeitet werden.
- **Methoden-Struktur:** Aufteilung des Codes in logische Einheiten (Methoden), um die Übersichtlichkeit zu wahren.
- **Umgang mit Datentypen:** Wahl des richtigen Datentyps für Währungsbeträge zur Vermeidung von Rundungsfehlern.
