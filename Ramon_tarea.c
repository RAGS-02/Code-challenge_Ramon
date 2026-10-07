#include <stdio.h>

int main() {
    int N, M;
    long long L, U;

    if (scanf("%d %d %lld %lld", &N, &M, &L, &U) != 4) {
        printf("ERROR");
        return 0;
    }

    // Validaciones obligatorias
    if (!(1 <= N && N <= 30 && 1 <= M && M <= 30 && 0 <= L && L <= U && U <= 1000)) {
        printf("ERROR");
        return 0;
    }

    int a[30][30];

    for (int i = 0; i < N; i++) {
        for (int j = 0; j < M; j++) {
            long long v;
            if (scanf("%lld", &v) != 1) {
                printf("ERROR");
                return 0;
            }
            if (!(0 <= v && v <= 1000)) {
                printf("ERROR");
                return 0;
            }
            a[i][j] = (int)v;
        }
    }

    int eventosFila[30] = {0};
    long long impactoFila[30] = {0};

    int rachaMax[30] = {0};
    int inicioRacha[30] = {0}; // si no hay eventos -> 0

    int eventosCol[30] = {0};

    int existeEvento = 0;

    // Eventos + impacto + rachas
    for (int i = 0; i < N; i++) {
        int bestLen = 0;
        int bestStart = 0;

        int curLen = 0;
        int curStart = 0;

        for (int j = 0; j < M; j++) {
            int esEvento = 0;

            // interior: 1..M-2
            if (1 <= j && j <= M - 2) {
                long long x = a[i][j];
                long long p = a[i][j - 1];
                long long q = a[i][j + 1];

                if ((x - p) >= L && (x - q) >= U) {
                    esEvento = 1;

                    long long impacto = (x - p) + (x - q) + 1;

                    eventosFila[i]++;
                    impactoFila[i] += impacto;
                    eventosCol[j]++;

                    existeEvento = 1;

                    // racha
                    if (curLen == 0) curStart = j;
                    curLen++;
                } else {
                    if (curLen > 0) {
                        if (curLen > bestLen || (curLen == bestLen && curStart < bestStart)) {
                            bestLen = curLen;
                            bestStart = curStart;
                        }
                    }
                    curLen = 0;
                }
            } else {
                // fuera de interior => no evento y cerrar racha si venía
                if (curLen > 0) {
                    if (curLen > bestLen || (curLen == bestLen && curStart < bestStart)) {
                        bestLen = curLen;
                        bestStart = curStart;
                    }
                }
                curLen = 0;
            }
        }

        // cerrar racha al final
        if (curLen > 0) {
            if (curLen > bestLen || (curLen == bestLen && curStart < bestStart)) {
                bestLen = curLen;
                bestStart = curStart;
            }
        }

        rachaMax[i] = bestLen;
        inicioRacha[i] = (bestLen == 0) ? 0 : bestStart;
    }

    // Prioridad de fila
    int prioridad = 0; // 0-based internamente
    if (existeEvento) {
        int mejor = 0;
        for (int i = 1; i < N; i++) {
            int mejorI = 0;

            if (rachaMax[i] > rachaMax[mejor]) mejorI = 1;
            else if (rachaMax[i] == rachaMax[mejor]) {
                if (impactoFila[i] > impactoFila[mejor]) mejorI = 1;
                else if (impactoFila[i] == impactoFila[mejor]) {
                    if (eventosFila[i] > eventosFila[mejor]) mejorI = 1;
                    else if (eventosFila[i] == eventosFila[mejor] && i < mejor) mejorI = 1;
                }
            }

            if (mejorI) mejor = i;
        }
        prioridad = mejor;
    }

    // Columna destacada
    int columnaDestacada = 0; // 0-based
    if (existeEvento) {
        int bestCol = 0;
        for (int j = 1; j < M; j++) {
            if (eventosCol[j] > eventosCol[bestCol]) bestCol = j;
            else if (eventosCol[j] == eventosCol[bestCol] && j < bestCol) bestCol = j;
        }
        columnaDestacada = bestCol;
    }

    // ===================== Salida =====================
    for (int i = 0; i < N; i++) {
        printf("FILA %d EVENTOS %d IMPACTO %lld RACHA %d INICIO %d\n",
               i + 1, eventosFila[i], impactoFila[i], rachaMax[i], inicioRacha[i]);
    }

    printf("COLUMNAS");
    for (int j = 0; j < M; j++) {
        printf(" %d", eventosCol[j]);
    }
    printf("\n");

    // prioridad: 1-based para FILA
    printf("PRIORIDAD %d\n", existeEvento ? (prioridad + 1) : 0);

    // columna destacada: 0-based
    printf("COLUMNA %d\n", existeEvento ? columnaDestacada : 0);

    return 0;
}