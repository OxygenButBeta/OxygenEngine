namespace OxygenEngine.Scripting {
    [Serializable]
    internal class KeyPair {
        public string name;
        public string value;

        internal KeyPair(string name, string value) {
            this.name = name;
            this.value = value;
        }
    }
}