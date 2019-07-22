# Eval_expr-Calculatrice-
recode de la fonction eval de php en c# .net avec interface graphique

Pour demarrer l'api dossier 'EVAL_EXPR_API'
commande: 'dotnet run'

Pour demarrer l'interface dossier 'my-app'
commande: 'npm run start'

pour envoyer des donner a l'api:
- route: '/api/bsq'
- headers: { 
              "Content-Type": "application/json" 
           }
- data: {
                "expr": (string) expression(ex: "3+4-1")
        }

- return: {
                "result": 6 (int)
          }
