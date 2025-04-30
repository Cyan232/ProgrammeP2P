# But et description du système
Le système consiste à un réseau P2P dans lequel la transmission de fichiers sera possible, ces fichiers seront placés dans un dossier qui sera donc dit partagé.  Pour envoyer les fichiers le protocole UDP sera utilisé.

# Lancement du programme et conteneurisation
Le programme de simulation peut être lancé à l’aide de la commande “docker compose up” qui s’occupe de créer un réseau virtuel et lance deux instances (un nœud initial et un voisin). Le réseau virtuel assigne des adresses statiques à chaque nœud. Les nœuds génèrent périodiquement des fichiers aléatoires afin de simuler une utilisation typique.

La simulation peut être terminée avec la commande “docker compose down” qui détruit les conteneurs et volumes afférents.
