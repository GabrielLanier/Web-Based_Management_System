<template>
  <div class="text-center">
    <div class="text-h4 q-mt-md text-primary">Tray Contents</div>
    <q-avatar class="q-mt-md" size="xl" square style="width: fit-content; height: fit-content">
      <img :src="`img/cart.png`" style="width: 150px; height: 150px" />
    </q-avatar>
    <div class="text-h6 text-positive">{{ state.status }}</div>
    <q-scroll-area style="height: 55vh">
      <q-item style="bottom: -2vh">
        <q-item-section class="col-4 q-ml-sm text-h6 text-primary">Name</q-item-section>
        <q-item-section class="q-ml-sm text-h6 text-primary text-left col-2">Qty</q-item-section>
        <q-item-section class="text-h6 text-primary col-3">MSRP</q-item-section>
        <q-item-section class="text-h6 text-primary col-3">Price</q-item-section>
      </q-item>
      <q-card class="q-ma-md">
        <q-list separator>
          <q-item clickable v-for="cartItem in state.cart" :key="cartItem.id">
            <q-item-section class="col-4">
              {{ cartItem.item.name }}
            </q-item-section>
            <q-item-section class="col-2">
              {{ cartItem.qty }}
            </q-item-section>
            <q-item-section class="col-3">${{ cartItem.item.costprice }}</q-item-section>
            <q-item-section class="col-3"
              >${{ cartItem.qty * cartItem.item.costprice }}</q-item-section
            >
          </q-item>
        </q-list>
      </q-card>

      <!-- Totals Section -->
      <!-- <div class="q-px-md text-right">
        <div>Sub: ${{ subtotal.toFixed(2) }}</div>
        <div>Tax(13%): ${{ tax.toFixed(2) }}</div>
        <div class="text-h6">Total: ${{ total.toFixed(2) }}</div>
      </div> -->
    </q-scroll-area>
    <div>
      <q-btn color="primary" icon="delete" label="Empty Cart" @Click="emptyCart()"></q-btn>
    </div>
  </div>
</template>
<script>
import { reactive, onMounted } from 'vue'
// import { useRouter } from 'vue-router'

export default {
  setup() {
    let state = reactive({
      status: '',
      cart: [],
      tax: 0.13,
      total: 0,
      subtotal: 0,
    })

    onMounted(() => {
      if (sessionStorage.getItem('cart')) {
        state.tray = JSON.parse(sessionStorage.getItem('tray'))
      }
    })

    const clearCart = () => {
      sessionStorage.removeItem('cart')
      state.cart = []
      state.status = 'Cart Emptied'
    }

    return { state, clearCart }
  },
}
</script>
