<template>
  <div class="text-h4 text-center q-mt-md q-mb-md text-primary">Login</div>
  <div class="text-title2 text-center text-positive text-bold q-mt-sm">{{ state.status }}</div>
  <q-card class="q-ma-md q-pa-md">
    <q-form ref="myForm" class="q-gutter-md" greedy @submit="login" @reset="resetFields">
      <q-input
        outlined
        placeholder="Email input"
        id="email"
        v-model="state.email"
        :rules="[isRequired, isValidEmail]"
      />
      <q-input
        outlined
        placeholder="Password input"
        id="password"
        v-model="state.password"
        type="password"
        :rules="[isRequired]"
      />
      <q-btn label="Login" type="submit" />
      <q-btn label="Reset" type="reset" />
    </q-form>
  </q-card>
</template>
<script>
import { poster } from '../utils/apiutil'
import { reactive } from 'vue'
import { useRouter } from 'vue-router'
export default {
  setup() {
    let state = reactive({
      status: '',
      email: '',
      password: '',
    })

    const router = useRouter()
    //const route = useRoute()

    const isRequired = (val) => {
      return !!val || 'field is required'
    }
    const login = async () => {
      let customerHelper = {
        email: state.email,
        password: state.password,
      }
      try {
        let payload = await poster('customer/login', customerHelper)
        if (!payload.token.includes('failed')) {
          sessionStorage.setItem('customer', JSON.stringify(payload))
          state.status = 'Login Successful'
          router.push({ path: '/' })
          //route.query.nextUrl ? router.push(router.query.nextUrl) : router.push('/')
        } else {
          state.status = payload.token
        }
      } catch (err) {
        state.status = err.message
      }
    }
    const resetFields = () => {
      state.email = ''
      state.password = ''
      state.status = ''
    }
    const isValidEmail = (val) => {
      const emailPattern =
        /^(?=[a-zA-Z0-9@._%+-]{6,254}$)[a-zA-Z0-9._%+-]{1,64}@(?:[a-zA-Z0-9-]{1,63}\.){1,8}[a-zA-Z]{2,63}$/
      return emailPattern.test(val) || 'Invalid email'
    }
    return {
      state,
      login,
      isRequired,
      resetFields,
      isValidEmail,
    }
  },
}
</script>
