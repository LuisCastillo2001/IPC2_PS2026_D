# 🧰 Comandos esenciales de Git

## 📦 Configuración inicial

```bash
git config --global user.name "Tu Nombre"
git config --global user.email "tu@email.com"
git config --list
```

---

## 📁 Iniciar un repositorio

```bash
git init                  # Inicializa un nuevo repositorio Git en el directorio actual
git clone <url>           # Clona un repositorio remoto
```

---

## 📄 Estados de los archivos

```bash
git status                # Muestra el estado actual del repositorio
git add <archivo>         # Añade archivo al área de staging
git add .                 # Añade todos los cambios
git restore <archivo>     # Revierte los cambios del archivo (no guardados)
git rm <archivo>          # Elimina archivo y lo marca para el commit
```

---

## ✅ Commits

```bash
git commit -m "mensaje"                   # Crea un commit con mensaje
git commit -am "mensaje"                  # Añade y commitea archivos ya versionados
git log                                   # Muestra historial de commits
git log --oneline --graph --all           # Historial gráfico simplificado
```

---

## 🌿 Ramas (branches)

```bash
git branch                 # Lista ramas locales
git branch <rama>          # Crea nueva rama
git checkout <rama>        # Cambia de rama
git checkout -b <rama>     # Crea y cambia a nueva rama
git merge <rama>           # Fusiona otra rama en la actual
git branch -d <rama>       # Elimina una rama local
```

---

## 🔄 Sincronización remota

```bash
git remote -v                           # Ver remotos configurados
git remote add origin <url>            # Conectar repositorio local con remoto
git push origin <rama>                 # Subir cambios
git push -u origin <rama>              # Subir y establecer rama por defecto
git pull origin <rama>                 # Obtener y fusionar últimos cambios
git fetch                              # Trae los cambios sin fusionarlos
```

---

## 🏷️ Etiquetas (tags)

```bash
git tag                              # Lista tags
git tag <nombre>                     # Crea un tag
git tag -a <nombre> -m "mensaje"     # Crea un tag con anotación
git push origin <nombre_tag>        # Sube un tag específico
git push origin --tags              # Sube todos los tags
```

---

## 🛠️ Otros útiles

```bash
git stash                           # Guarda cambios temporales
git stash pop                       # Restaura lo guardado y elimina el stash
git diff                            # Muestra cambios no agregados
git reset --hard HEAD               # Revierte a último commit descartando cambios
git clean -fd                       # Elimina archivos/directorios no rastreados
```

---

## 🧹 Resolver conflictos

```bash
# Después de un conflicto de fusión:
git status                          # Ver archivos en conflicto
# Editar manualmente los archivos para resolver conflictos
git add <archivo_resuelto>         # Marcar como resuelto
git commit                         # Confirmar resolución
```

---

## 🧪 Buenas prácticas

- Hacer commits pequeños y frecuentes con mensajes claros.
- Usar ramas para nuevas funcionalidades o arreglos.
- Hacer `pull` antes de `push` para evitar conflictos.
- Etiquetar versiones estables con `git tag`.

---


