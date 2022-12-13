
const soloDom = [45, 50, 55];
const soloVisio = [33, 40, 45];
const binomeDom = [26, 28, 30];
const binomeVisio = [20, 23, 26];


/*function calculerPrix(n) {              // pour test initial
    document.getElementById("prixCours").innerHTML = 20 * n;

}

/* paramètres nécessaires :
nb de créneaux
niveau
estDistanciel
enBinome */

function calculerPrix(n, niv, estDist, enBin) {    // niv = rang du groupe de niveaux dans l'énumération
    let prixHoraire=0;
    if (estDist) {
        if (enBin) {
            prixHoraire = binomeVisio[niv];
        }
        else {
            prixHoraire = soloVisio[niv];
        }
    }
    else {
        if (enBin) {
            prixHoraire = binomeDom[niv];
        }
        else {
            prixHoraire = soloDom[niv];
        }
    }
    return n * prixHoraire / 2;
}
