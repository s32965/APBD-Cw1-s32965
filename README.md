Instrukcja uruchomienia:
1. Zbuduj:
    dotnet build src

2. Uruchom:
    dotnet run --project src


## Kohezja, coupling i odpowiedzialność:
#### Kohezja:
W moim kodzie kohezja zachodzi na poziomie serwisów.
Na przykład serwis RentalService realizuje jedynie metody związane z wynajmem,
tymczase serwis EquipmentService realizuje metody działające bezpośrednio na przedmiotach.
Oba te serwisy mają jasno określone i niezależne role.

#### Coupling:
W moim kodzie coupling jest realizowany na domenach.
Na przykład klasy Employee i Student są sprzężone z klasą abstracyjną User.
Oznacza to że klasy te opierają się na klasie User.
Jest to tight coupling, ponieważ zmiana w klasie User musi zostać zaimplementowana w klasach pochodnych.

#### Odpowiedzialność:
Podobnie do kohezji, odpowiedzialność jest realizowana w serwisach.
Jest to jednak tak zwany "Fat Service", ponieważ implementuje kilka odpowiedzialności, w tym:
1. przechowywanie danych
2. przeszukiwanie danych

## Uzasadnienie podjętych decyzji:
Podzieliłem kod za względu na funkcję w programie. To znaczy, cały kod podzieliłem na 4 kategorie: Enums, Exceptions, Models, Services.
1. Enums - ta kategoria zawiera enumy określające z góry określone stany
2. Exceptions - zawiera wyjątki występujące w programie
3. Models - zawiera klasy najmniejsze (najbardziej podstawowe) w programie
4. Services - serwisy zawarte w tej kategorii operują na klasach w kategorii Models żeby osiągnąć bardziej zaawansowaną funkcjonalność

Wybrałem taki układ, ponieważ jest czytelny. Pozwala szybko zrozumieć układ projektu i prędko zacząć dodawać nową funkcjonalność.
