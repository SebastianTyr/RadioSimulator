# RadioSimulator
- projekt zaliczeniowy z programowania w środowisku ASP.NET Core

# Założenia
- projekt zakłada stworzenie symulatora linii alarmowej 112, w którym użytkownik może wcielić się zarówno w dyspozytora prowadzącego ewidencję sprzętu, co w operatora linii mającego dostęp do mapy departamentów jednostek oraz wysyłania ich na miejsce zdarzenia

# Użyte technologie
- ASP.NET Core MVC
- Entity Framework
- Cookie Authentication
- Role-based authorization
- LeafletJS
- Open street maps
- Fluent Validation

# Instalacja
- należy pobrać symulator w postaci pliku zip
- następnie uruchomić symulator i cieszyć się z zabawy :)

# Opis Działania aplikcaji
Aplikacja jest prostym symulatorem linii alarmowej 112 i ma na celu pokazanie działania podobnych produkcyjnych systemów. Jest podzielona na dwie role oparte na logowaniu: Administrator, którym jest dyspozytor prowadzący ewidencję krótkofalówek oraz Operator, który rejestruje zgłoszenie i wysyła jednostkę. 

Dyspozytor może rejestrować oraz edytować dane krótkofalówek, ma dostęp do CRUD-a aplikacji, natomiast operator widzi mapę ze statycznymi punktami prezentującymi departementy poszczególnych jednostek. W zależności od rodzaju zgłoszenia, operator wybiera odpowiedni departament i wysyła jednostkę na miejsce zdarzenia. 

Operator widzi również wyrysowaną trasę jednostki oraz szacowany czas przyjazdu, następnie rejestruje zgłoszenie i wysyła jednostkę.
