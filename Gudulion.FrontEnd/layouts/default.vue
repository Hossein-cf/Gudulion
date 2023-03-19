<template>
  <v-app dark>
    <v-app-bar fixed app>
      GUDULION
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer absolute app>
      <span>&copy; {{ new Date().getFullYear() }} Gudulion Group</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
}
</script>
