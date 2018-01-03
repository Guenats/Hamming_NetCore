
**Guénael ANSELME - EPSI I4C1**


**Langage de développement**

J'ai utilisé .Net Core pour développer mon programme. 
Il peut se déployer sur n'importe quel plateforme. 

**Installation**

Pour les plateforme Linux :
https://www.microsoft.com/net/learn/get-started/linuxredhat
Pour Mac : 
https://www.microsoft.com/net/learn/get-started/macos

Pour Windows:
https://www.microsoft.com/net/learn/get-started/macos

Pour lancer l'application, se mettre dans le dossier du projet,ou le fichier .csproj est situé et lancer la commande dotnet run




**TP - Distance de hamming**


*Matrice d'exemple*

|    |  1  |  2  |  3  |  4  |
|----|-----|-----|-----|-----|
| 1  |  T  |  F  |  F  |  T  |
| 2  |  T  |  T  |  F  |  T  |
| 3  |  F  |  F  |  F  |  T  |
| 4  |  T  |  F  |  T  |  T  |
| 5  |  T  |  F  |  F  |  F  |
| 6  |  T  |  T  |  T  |  F  |
| 7  |  F  |  F  |  F  |  F  |
| 8  |  F  |  T  |  T  |  T  |
| 9  |  F  |  T  |  T  |  F  |
| 10 |  F  |  F  |  T  |  F  |


*Question a*

Le tableau ci dessous représente les distance de hamming


|   |  1  |  2  |  3  |  4  |  5  |  6  |  7  |  8  |  9  |  10 |
|---|-----|-----|-----|-----|-----|-----|-----|-----|-----|-----|
|1  |  -  |  1  |  1  |  1  |  1  |  3  |  2  |  3  |  4  |  3  |
|2  |  1  |  -  |  2  |  2  |  2  |  2  |  3  |  2  |  3  |  4  |
|3  |  1  |  2  |  -  |  2  |  2  |  4  |  1  |  2  |  3  |  2  |
|4  |  1  |  2  |  2  |  -  |  2  |  2  |  3  |  2  |  3  |  2  |
|5  |  1  |  2  |  2  |  2  |  -  |  2  |  1  |  4  |  3  |  2  |
|6  |  3  |  2  |  4  |  2  |  2  |  -  |  3  |  2  |  1  |  2  |
|7  |  2  |  3  |  1  |  3  |  1  |  3  |  -  |  3  |  2  |  1  |
|8  |  3  |  2  |  2  |  2  |  4  |  2  |  3  |  -  |  1  |  2  |
|9  |  4  |  3  |  3  |  3  |  3  |  1  |  2  |  1  |  -  |  1  |
|10 |  3  |  4  |  2  |  2  |  2  |  2  |  1  |  2  |  1  |  -  |

Pour connaitre les distance de hamming , il suffit de calculer les différence entre les ligne de la matrice donnée.


**Question b)**

Dans un premier temps, j'ai voulu séparé les lignes de la matrices dans n clusters différents suivant la moyenne des distance de hamming retrouvé 

Je me suis donc retrouvé avec 2 clusters pour la matrice d'exemple

Cluster 1 : Moyenne de 1.88

ligne de matrice 1,3,4,5,7,10

Cluster 2 : Moyenne de 1.66

ligne de matrice 2,6,8,9

Cela correspond au nombre de caractère à changer dans chaque ligne pour arrivé à une égalité entre deux ligne. 

Puis j'ai recalculé les distance d'hamming de chaque cluster. En faisant cela, on determine les valeurs qui se rapproche le plus entre elle.

Quand un cluster ne contenait que 1 valeur, on déplace une valeur d'un cluster avec la moyenne la plus grande 

Je n'ai pas réussi à trouver une condition d'arrêt pour que la recherche se termine.

**Organisation**

J'ai tout d'abord posé le problème sur papier. Discuté avec mes camarades sans forcement parler "Code". 

Une fois le problème posé, j'ai commencé à développer.


