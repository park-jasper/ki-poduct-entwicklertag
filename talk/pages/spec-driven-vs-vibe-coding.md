---
layout: center
---

<style>
.slidev-layout table {
	border-collapse: collapse;
	width: 100%;
}

.slidev-layout th,
.slidev-layout td {
	padding: 4px;
}

.slidev-layout th {
	background-color: var(--bh-light-blue);
}
</style>

# Unterschied zwischen Spec-Driven Development vs. Vibe-Coding

| Feature | Vibe-Coding | Spec-Driven Development |
|---|---|---|
| Start | "Ich habe eine Idee, und fange an Code zu generieren" | Zusammentragen formaler Grundlagen (requirements.md) |
| Logik | Iteratives "Fixen und Schauen" | KI-getriebene Suche nach wiederverwendbaren Patterns _bevor_ Code geschrieben wird |
| Dokumentation | wenig bis keine | Die Spezifikation (spec.md) ist das primäre Artefakt, der Code ist nur das Resultat der Spezifikation |
| Fehlerbehandlung | Oft vergessen oder generisch | Vordefiniert in den Projekteigenen Standards |
| Verifikation | "It works on my machine" | Die Spezifikation schreibt Tests vor, die zur Verifizierung des Code genutzt werden |