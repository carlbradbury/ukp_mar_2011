namespace nothinbutdotnetprep.utility.filtering
{
    public class CriteriaFactory<ItemToFilter, ReturnType>
    {
        private  PropertyAccessor<ItemToFilter, ReturnType> property_accessor;


        public CriteriaFactory(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public object equal_to(ReturnType value_to_equal)
        {
            return new ConditionalCriteria<ItemToFilter>(m => property_accessor(m).Equals(value_to_equal));
        }

        public object equal_to_any(params ReturnType[] values_to_equal)
        {
            return new ConditionalCriteria<ItemToFilter>(m => property_accessor(m).equals_any(values_to_equal));
        }
    }
}