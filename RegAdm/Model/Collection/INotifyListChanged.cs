namespace Model.Collection
{
    public delegate void NotifyListChangedEventHandler<T>(object sender, NotifyCollectionChangedAction<T> e);
}
