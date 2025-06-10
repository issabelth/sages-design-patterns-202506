# Problemy z podejściem bez wzorca 

## 1. Złożoność rośnie wykładniczo:
- W miarę dodawania nowych zasad obliczania urlopu kod staje się trudniejszy do zrozumienia i utrzymania. Każda zmiana wymaga modyfikacji klasy `EmployeeLeave`.
- Logika obliczeń jest scentralizowana, co łamie zasadę **Single Responsibility**.

## 2. Brak elastyczności:
- Jeżeli wprowadzimy nową regułę (np. dodatkowe dni za pracę w trudnych warunkach), musimy edytować istniejącą klasę `EmployeeLeave`, co może prowadzić do regresji w działaniu.
- Dodanie nowej reguły wymaga wprowadzenia zmian w istniejącej klasie co łamie zasadę **Open/Closed**.

## 3. Trudność w testowaniu:
- Jedna klasa zawiera logikę wszystkich reguł obliczania, co utrudnia jej testowanie w izolacji.

## 4. Brak możliwości dynamicznego rozszerzania:
- Aby zmodyfikować sposób obliczania urlopu dla jednego pracownika, trzeba stworzyć nowy obiekt `EmployeeLeave`, co może wymagać przepisania kodu.