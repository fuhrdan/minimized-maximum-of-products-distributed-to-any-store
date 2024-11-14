//*****************************************************************************
//** 2064. Minimized Maximum of Products Distributed to Any Store   leetcode **
//*****************************************************************************

int isValidDistributionCheck(int n, int mid, int* quantities, int quantitiesSize) {
    for (int i = 0; i < quantitiesSize; i++) {
        int requiredShops = (quantities[i] + mid - 1) / mid;
        
        n -= requiredShops;
        if (n < 0) 
            return 0;
    }
    return 1;
}

int minimizedMaximum(int n, int* quantities, int quantitiesSize) {
    int low = 1;
    int high = quantities[0];
    for (int i = 1; i < quantitiesSize; i++) {
        if (quantities[i] > high) {
            high = quantities[i];
        }
    }

    int max_dis = high;

    while (low <= high) {
        int mid = low + (high - low) / 2;

        if (isValidDistributionCheck(n, mid, quantities, quantitiesSize)) {
            max_dis = mid;
            high = mid - 1;
        } else {
            low = mid + 1;
        }
    }

    return max_dis;
}
