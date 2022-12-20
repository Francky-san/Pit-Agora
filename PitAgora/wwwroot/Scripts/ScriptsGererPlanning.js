function changerStatut(obj) {
    if (statut == "cellulePlanning dispo") {              // le créneau était disponible pour un cours
        obj.className = "cellulePlanning nonPropose";
        if (aAjouter.has(obj.id)) {                         // le créneau avait déjà changé de statut                
            aAjouter.delete(obj.id)
        }
        else {
            aRetirer.add(obj.id)
        }
    }
    else {                                                   // le créneau était 'non proposé'
        obj.className = "cellulePlanning dispo";
        if (aRetirer.has(obj.id)) {                         // le créneau avait déjà changé de statut                
            aRetirer.delete(obj.id)
        }
        else {
            aAjouter.add(obj.id)
        }
    }
    statut = obj.className;
    majRetourAjoutes(aAjouter);
    majRetourRetires(aRetirer);
}

function mOver(obj) {
    statut = obj.className;
    obj.className = "cellulePlanning survole";
}

function mOut(obj) {
    obj.className = statut;
}

// Place dans l'input caché une string contenant les Id des créneaux à retirer au prof
function majRetourRetires(selection) {
    let res = "";
    for (let id of selection) {
        res += id + ",";
    }
    document.getElementById("retourASupprimer").value = res;
}

// Place dans l'input caché une string contenant les Id des créneaux à ajouter au prof
function majRetourAjoutes(selection) {
    let res = "";
    for (let id of selection) {
        res += id + ",";
    }
    document.getElementById("retourAAjouter").value = res;
}

// Demander confirmation avant d'envoyer la requête
function demanderConfirmation() {
    let confirm = window.confirm("Je confirme ma réservation\nle " + document.getElementById("jour").innerHTML
        + "\n\nRappel : un cours annulé moins de 48h à l'avance ne sera pas remboursé");
    if (confirm) {
        document.getElementById("choixCours").action = "../CreerReservation"
    }
    else {
        document.getElementById("choixCours").action = ""
    }
}