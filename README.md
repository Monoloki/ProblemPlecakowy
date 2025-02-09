# ProblemPlecakowy
Rozwiązanie problemu plecakowego dwuelementową strategią ewolucyjną

Problem plecakowy (ang. Knapsack Problem) polega na wyborze podzbioru przedmiotów o określonych wartościach i objętościach tak, aby ich łączna objętość nie przekraczała pojemności plecaka, a suma wartości była maksymalna. W tej wersji problemu:

Plecak ma maksymalną objętość 2500 jednostek.
Istnieje 100 przedmiotów, każdy o objętości z zakresu 10-90 jednostek.
Celem jest znalezienie najlepszego zbioru przedmiotów przy użyciu strategii ewolucyjnej (μ+1).

Opis rozwiązania

1. Program na początku tworzy 100 losowych przedmiotów z zakresu objętości od 10 do 90 i wypisuje je w konsoli.
2. Losowe rozwiązanie jest generowane jako lista 100 wartości binarnych (0/1), gdzie:
3. 
1 oznacza, że dany przedmiot jest w plecaku.
0 oznacza, że dany przedmiot nie został wybrany.
Rozwiązanie jest akceptowane tylko wtedy, gdy jego łączna objętość nie przekracza 2500 jednostek.

4. Algorytm iteracyjnie ulepsza rozwiązanie, aby znaleźć najlepszy możliwy zestaw przedmiotów. Proces przebiega według następujących kroków:
Wybierany jest losowy indeks w liście (0 lub 1) i wartość zostaje zmieniona.
Sprawdzana jest objętość nowego rozwiązania.
Jeśli nowa objętość przekracza limit 2500, mutacja jest odrzucana.
Selekcja:

Jeśli mutacja prowadzi do lepszego rozwiązania (wrozwiązanie bliżej limitu), nowe rozwiązanie zastępuje stare.
W przeciwnym razie pozostaje poprzednie rozwiązanie.
Kryteria zakończenia:

Algorytm kończy działanie po 1000 pokoleń.
Algorytm kończy działanie po 2000 nieudanych mutacjach.
Algorytm kończy działanie po 5 minutach pracy.

4. Wyniki końcowe
Po zakończeniu algorytmu program wypisuje:
Łączną wartość wybranych przedmiotów.
Łączną objętość wybranych przedmiotów.
Binarną reprezentację rozwiązania (ciąg 0 i 1).
Objętości wybranych przedmiotów.
