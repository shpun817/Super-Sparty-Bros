using System;

public class CircularStack<T> {

    private T[] _arr;
    private int _maxSize; // This is fixed
    private int _size;
    private int _top;
    private int _bottom;

    public CircularStack (int maxSize) {
        if (maxSize <= 0)
            throw new OverflowException("Size of CircularStack not positive.");
        _arr = new T[maxSize];
		for (int i = 0; i < maxSize; ++i) {
			_arr[i] = default(T);
		}
        _size = _top = _bottom = 0;
        _maxSize = maxSize;
    }

    public int GetSize() { return _size; }
    public int GetMaxSize() { return _maxSize; }

    public void Push(T obj) {
        if (_size == 0) {
            _arr[_top] = obj;
            ++_size;
            return;
        }
        _top = _top + 1;
        _top = _top % _maxSize;
        if (_top == _bottom) {
            _bottom = (_bottom+1) % _maxSize;
        }
        _arr[_top] = obj;
        if (_size < _maxSize)
            ++_size;
    }

	public T Peek() {
		if (_size <= 0) return default(T);
		return _arr[_top];
	}

    public T Pop() {
        if (_size <= 0) return default(T);
        T obj = _arr[_top];
		if (_top > 0) {
			--_top;
		}
        --_size;
        return obj;
    }

    public void Resize(int newSize) {
        if (newSize <= 0)
			throw new OverflowException("Size of CircularStack not positive.");
        T[] tempArr = new T[newSize];
		int tempSize = newSize<_size?newSize:_size;
		for (int i = 0; i < tempSize; ++i) {
			tempArr[i] = _arr[(_bottom+i)%_maxSize];
		}
		_arr = tempArr;
		_size = tempSize;
		_bottom = 0;
		_top = _size-1;
		_maxSize = newSize;
    }

	public void Clear() {
		for (int i = 0; i < _maxSize; ++i) {
			_arr[i] = default(T);
		}
        _size = _top = _bottom = 0;
	}

    public override String ToString() {
        String str = "";
        for (int i = 0; i < _size; ++i) {
            str += _arr[(_bottom+i)%_maxSize] + " ";
        }
        return str.TrimEnd();
    }

}

/* FOR TESTING
class Program
{
	static void Main(string[] args)
	{
		CircularStack<int> cs = new CircularStack<int>(5);
		cs.Push(2);
		cs.Push(1);
		cs.Push(3);
		cs.Push(4);
		cs.Push(11);
		cs.Resize(3);
		cs.Resize(4);
		Console.WriteLine(cs.Peek());
		Console.WriteLine(cs);
	}
}
*/