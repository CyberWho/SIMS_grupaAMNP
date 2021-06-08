namespace Hospital.Model
{
    public class Secretary : RoleDescriptionBase
    {
        private int id;
        public override int howMuchAmIPaid()
        {
            return wrappee.howMuchAmIPaid() + 30000;
        }

        public override string describeMyRole()
        {
            return wrappee.describeMyRole() + "Vi ste ste sekretar\n";
        }

        public Secretary(int id, IRoleDescriptior ird)
        {
            this.wrappee = ird;
            this.id = id;
        }
    }
}